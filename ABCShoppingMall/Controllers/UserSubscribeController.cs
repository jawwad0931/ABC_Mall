using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCShoppingMall.Data;
using ABCShoppingMall.Models;

namespace ABCShoppingMall.Controllers
{
    public class UserSubscribeController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: UserSubscribe
        public ActionResult Index()
        {
            return View(db.Subscribes.ToList());
        }

        // GET: UserSubscribe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // GET: UserSubscribe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSubscribe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Subscribes.Add(subscribe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscribe);
        }

        // GET: UserSubscribe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: UserSubscribe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscribe);
        }

        // GET: UserSubscribe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: UserSubscribe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscribe subscribe = db.Subscribes.Find(id);
            db.Subscribes.Remove(subscribe);
            db.SaveChanges();
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
