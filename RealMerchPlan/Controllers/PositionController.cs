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
    public class PositionController : Controller
    {
        private RealMerchContext db = new RealMerchContext();

        // GET: Position
        public ActionResult Index()
        {
            var positions = db.Positions.Include(p => p.Fixture).Include(p => p.UPCScan);
            return View(positions.ToList());
        }

        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            ViewBag.FixtureId = new SelectList(db.Fixtures, "FixtureID", "FixtureID");
            ViewBag.UPCId = new SelectList(db.UPCScans, "UPCId", "UPCId");
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,FixtureId,UPCId,XLocation,YLocation")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FixtureId = new SelectList(db.Fixtures, "FixtureID", "FixtureID", position.FixtureId);
            ViewBag.UPCId = new SelectList(db.UPCScans, "UPCId", "UPCId", position.UPCId);
            return View(position);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixtureId = new SelectList(db.Fixtures, "FixtureID", "FixtureID", position.FixtureId);
            ViewBag.UPCId = new SelectList(db.UPCScans, "UPCId", "UPCId", position.UPCId);
            return View(position);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,FixtureId,UPCId,XLocation,YLocation")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixtureId = new SelectList(db.Fixtures, "FixtureID", "FixtureID", position.FixtureId);
            ViewBag.UPCId = new SelectList(db.UPCScans, "UPCId", "UPCId", position.UPCId);
            return View(position);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
