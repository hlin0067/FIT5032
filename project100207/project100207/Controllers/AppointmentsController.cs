using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using project100207.Models;

namespace project100207.Controllers
{
    public class AppointmentsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Appointments
        [Authorize]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var appointmentSet = db.AppointmentSet.Include(a => a.AspNetUsers).Where(a => a.AspNetUsersId == currentUserId);
            return View(appointmentSet.ToList());
            //var appointmentSet = db.AppointmentSet.Include(a => a.AspNetUsers);
            //return View(appointmentSet.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Id");
            ViewBag.AspNetUsersId = User.Identity.GetUserId();
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,Doctor,Date,Description,AspNetUsersId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentSet.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor = new SelectList(db.AspNetUsers, "Id", "Id", appointment.AspNetUsersId);
            ViewBag.AspNetUsersId = User.Identity.GetUserId();
            //ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", appointment.AspNetUsersId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUsersId = User.Identity.GetUserId();
            //ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", appointment.AspNetUsersId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,Doctor,Date,Description,AspNetUsersId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", appointment.AspNetUsersId);
            ViewBag.AspNetUsersId = User.Identity.GetUserId();
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.AppointmentSet.Find(id);
            db.AppointmentSet.Remove(appointment);
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
