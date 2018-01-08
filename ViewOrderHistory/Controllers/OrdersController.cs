using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Order_DB;
using ViewOrderHistory.DAL;
namespace ViewOrderHistory.Controllers
{
    public class OrdersController : Controller

    {
        
        public ViewOrderHistory.DAL.IViewOrderHistoryRepository db;
        public ViewOrderHistory.Models.MockProductsContext productsdb;

        public OrdersController(IViewOrderHistoryRepository repository)
        {
            this.db = repository;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var AllOrders = db.GetOrder();

            var Orders = (from a in Order_DB.Order
                          join c in productsdb. on a.UserID equals c.UserID
                          where c.ClientID == yourDescriptionObject.ClientID
                          select a.Balance)
              .SingleOrDefault();

            return View(AllOrders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {

            var OrderDetails = db.GetOrdersByID(id);
            if (OrderDetails == null)
            {
                return HttpNotFound();
            }
            return View(OrderDetails);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,CustomerFirstName,CustomerSurname,CustomerPhoneNo,CustomerAddress,ProductID,ProductsOrdered,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.InsertOrder(order);
                if (order == null)
                {
                    return HttpNotFound();
                }
                db.Save();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var OrderDetails = db.GetOrdersByID(id);
            if (OrderDetails == null)
            {
                return HttpNotFound();
            }
            return View(OrderDetails);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,CustomerFirstName,CustomerSurname,CustomerPhoneNo,CustomerAddress,ProductID,ProductsOrdered,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.UpdateOrder(order);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {

            var OrderDetails = db.GetOrdersByID(id);
            if (OrderDetails == null)
            {
                return HttpNotFound();
            }
            return View(OrderDetails);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var OrderDetails = db.GetOrdersByID(id);
            db.DeleteOrder(id);
            if (OrderDetails == null)
            {
                return HttpNotFound();
            }
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