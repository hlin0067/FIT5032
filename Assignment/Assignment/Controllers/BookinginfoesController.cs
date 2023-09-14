using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class BookinginfoesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Bookinginfoes
        public ActionResult Index()
        {
            var bookinginfoes = db.Bookinginfoes.Include(b => b.AspNetUser);
            return View(bookinginfoes.ToList());
        }

        // GET: Bookinginfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookinginfo bookinginfo = db.Bookinginfoes.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinginfo);
        }

        // GET: Bookinginfoes/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Bookinginfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingDate,BookingDesc,AspNetUserId")] Bookinginfo bookinginfo)
        {
            if (ModelState.IsValid)
            {
                db.Bookinginfoes.Add(bookinginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", bookinginfo.AspNetUserId);
            return View(bookinginfo);
        }

        // GET: Bookinginfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookinginfo bookinginfo = db.Bookinginfoes.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", bookinginfo.AspNetUserId);
            return View(bookinginfo);
        }

        // POST: Bookinginfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingDate,BookingDesc,AspNetUserId")] Bookinginfo bookinginfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookinginfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", bookinginfo.AspNetUserId);
            return View(bookinginfo);
        }

        // GET: Bookinginfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookinginfo bookinginfo = db.Bookinginfoes.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinginfo);
        }

        // POST: Bookinginfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookinginfo bookinginfo = db.Bookinginfoes.Find(id);
            db.Bookinginfoes.Remove(bookinginfo);
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
