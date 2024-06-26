﻿using System;
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
    public class UserMoviesController : Controller
    {
        private ABCShoppingMallContext db = new ABCShoppingMallContext();

        // GET: UserMovies
        // GET: GalleriesUser
        public ActionResult Index()
        {
            var images = db.Movies.ToList();
            ViewBag.ImageId = images;

            return View(images);
        }

        public ActionResult DisplayMoviesImage(int id)
        {

            //var image = db.ShoppingCenters.Find(id);
            var image = db.Movies.FirstOrDefault(x => x.Id == id);

            return File(image.Image, "image/jpeg");
        }

        // GET: UserMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: UserMovies/Create
        public ActionResult Create()
        {
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name");
            return View();
        }

        // POST: UserMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MultiplexId,SeatsAvailable,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name", movie.MultiplexId);
            return View(movie);
        }

        // GET: UserMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name", movie.MultiplexId);
            return View(movie);
        }

        // POST: UserMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MultiplexId,SeatsAvailable,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiplexId = new SelectList(db.Multiplexes, "Id", "Name", movie.MultiplexId);
            return View(movie);
        }

        // GET: UserMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: UserMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
