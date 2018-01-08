using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserDB;
using ViewCustomers.DAL;

namespace ViewCustomers.Controllers
{
    public class UsersController : Controller
    {

        private ViewCustomers.DAL.IUserRepository db;
        
        public UsersController(IUserRepository repository)
        {
            this.db = repository;
        }

       // [Authorize]
        public ActionResult Index()
        {
            var allUsers = db.GetUser();
            var allUsersByActive = from a in allUsers orderby a.Active select a;

            return View(allUsersByActive);
        }

        // GET: Users/Details/5
       // [Authorize]
        public ActionResult Details(int id)
        {
            var UserDetails = db.GetUserByID(id);

            return View(UserDetails);
        }
      //  [Authorize]
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize]
        public ActionResult Create([Bind(Include = "UserID,FirstName,Surname,DOB,FirstLineAddress,SecondLineAddress,PostCode,Active,Deleted")] User user)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                db.InsertUser(user);
                db.Save();
                return RedirectToAction("Index");
                }
                catch (Exception ex) // catches all exceptions
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("", "Error");
   

            return View(user);
        }
        //[Authorize]
        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var UserDetails = db.GetUserByID(id);
                if (UserDetails == null)
                {
                    return HttpNotFound();
                }
                return View(UserDetails);
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      // [Authorize]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,Surname,DOB,FirstLineAddress,SecondLineAddress,PostCode,Active,Deleted")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateUser(user);
                    db.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) // catches all exceptions
                {
                    return View(ex.Message);
                }
            }
                return View(user);
        }
       // [Authorize]
        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var UserDetails = db.GetUserByID(id);
                if (UserDetails == null)
                {
                    return HttpNotFound();
                }
                return View(UserDetails);
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
         
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var UserDetails = db.GetUserByID(id);
            db.DeleteUser(id);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
