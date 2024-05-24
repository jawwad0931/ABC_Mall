using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCShoppingMall.Controllers
{
    public class UserTicketController : Controller
    {
        // GET: UserTicket
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserTicket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserTicket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTicket/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTicket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserTicket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTicket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserTicket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
