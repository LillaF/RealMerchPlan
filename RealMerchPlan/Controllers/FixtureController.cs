﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealMerchPlan.DAL;
using RealMerchPlan.Models;

namespace RealMerchPlan.Controllers
{
    public class FixtureController : Controller
    {
        private RealMerchContext db = new RealMerchContext();

        // GET: Fixture
        public ActionResult Index()
        {
            var fixtures = db.Fixtures.Include(f => f.Bay);
            return View(fixtures.ToList());
        }

        // GET: Fixture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: Fixture/Create
        public ActionResult Create()
        {
            ViewBag.BayID = new SelectList(db.Bays, "BayID", "BayID");
            return View();
        }

        // POST: Fixture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FixtureID,BayID,FixtureType,Height,Width,Depth,XLocation,YLocation")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Fixtures.Add(fixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BayID = new SelectList(db.Bays, "BayID", "BayID", fixture.BayID);
            return View(fixture);
        }

        // GET: Fixture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.BayID = new SelectList(db.Bays, "BayID", "BayID", fixture.BayID);
            return View(fixture);
        }

        // POST: Fixture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FixtureID,BayID,FixtureType,Height,Width,Depth,XLocation,YLocation")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BayID = new SelectList(db.Bays, "BayID", "BayID", fixture.BayID);
            return View(fixture);
        }

        // GET: Fixture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: Fixture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            db.Fixtures.Remove(fixture);
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
