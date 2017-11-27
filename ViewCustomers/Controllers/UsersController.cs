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
       // private UserContext db = new UserContext();

        private ViewCustomers.DAL.IUserRepository db;
        
        // Use constructor injection here
        public UsersController(IUserRepository repository)
        {
            this.db = repository;
        }


        //public UsersController()
        //{
        //    this.db = new ViewCustomers.DAL.UserRepository(new UserContext());
        //}

        // GET: Users
        public ActionResult Index()
        {
            var allUsers = db.GetUser();
            return View(allUsers);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var UserDetails = db.GetUserByID(id);

            return View(UserDetails);
        }

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
        public ActionResult Create([Bind(Include = "FirstName,Surname,DOB,FirstLineAddress,SecondLineAddress,PostCode,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                db.InsertUser(user);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
           
            var UserDetails = db.GetUserByID(id);
            if (UserDetails == null)
            {
                return HttpNotFound();
            }
            return View(UserDetails);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,Surname,DOB,FirstLineAddress,SecondLineAddress,PostCode,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                db.UpdateUser(user);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
  
            var UserDetails = db.GetUserByID(id);
            if (UserDetails == null)
            {
                return HttpNotFound();
            }
            return View(UserDetails);
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
