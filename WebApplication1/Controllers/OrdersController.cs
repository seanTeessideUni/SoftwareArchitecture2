using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using testdb;

using WebApplication1.Models;

namespace WebApplication1.Controllers

{

    public class OrdersController : Controller

    {

        [AcceptVerbs(HttpVerbs.Get)]

        public ActionResult Index()

        {

            public testdb = new testdb(); //dbcontect class

            List<CustomerVM> CustomerVMlist = new List<CustomerVM>(); // to hold list of Customer and order details

            var customerlist = (from Cust in orderdb.Customers

                                join Ord in orderdb.Orders on Cust.CustomerID equals Ord.CustomerID

selectnew { Cust.Name, Cust.Mobileno, Cust.Address, Ord.OrderDate, Ord.OrderPrice}).ToList();

            //query getting data from database from joining two tables and storing data in customerlist

            foreach (var item in customerlist)

            {

                CustomerVM objcvm = new CustomerVM(); // ViewModel

                objcvm.Name = item.Name;

                objcvm.Mobileno = item.Mobileno;

                objcvm.Address = item.Address;

                objcvm.OrderDate = item.OrderDate;

                objcvm.OrderPrice = item.OrderPrice;

                CustomerVMlist.Add(objcvm);

            }

            //Using foreach loop fill data from custmerlist to List<CustomerVM>.

            return View(CustomerVMlist); //List of CustomerVM (ViewModel)

        }

    }

}