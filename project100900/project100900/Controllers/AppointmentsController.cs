using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using project100900.Models;
using Rotativa;

namespace project100900.Controllers
{
    public class AppointmentsController : Controller
    {
        private Appointmentviewmodel db = new Appointmentviewmodel();

        // GET: Appointments
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var allappointments = db.Appointments.ToList();
                return View(allappointments);
            }
            var userId = User.Identity.GetUserId();
            var appointments = db.Appointments.Where(s => s.UserId ==
            userId||s.DoctorId == userId).ToList();
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize]
        public ActionResult Create()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var doctorRole = roleManager.FindByName("Doctor");
            var doctorRoleId = roleManager.FindByName("Doctor").Id;
            var doctors = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == doctorRoleId)).ToList();
            List<string> doctorUserNames = doctors.Select(d => d.UserName).ToList();
            ViewBag.DoctorUserNames = doctorUserNames;
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "AppointmentID,UserId,DoctorName,DoctorId,Date,Description")] Appointment appointment)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            appointment.UserId = User.Identity.GetUserId();
            var doctor = userManager.FindByName(appointment.DoctorName);
            if (doctor != null)
            {
                appointment.DoctorId = doctor.Id; // 设置DoctorId为找到的医生的UserId
            }
            else
            {
                ModelState.AddModelError("", "No doctor found with the specified name."); // 如果没有找到医生，向模型状态添加错误
            }

            ModelState.Clear();
            TryValidateModel(appointment);
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,UserId,DoctorName,DoctorId,Date,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
        public ActionResult PrintPDF()
        {
            var Data = db.Appointments.ToList();
            return new PartialViewAsPdf("PrintPDF", Data)
            {
                FileName = "TestPartialViewAsPdf.pdf"
            };
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = db.Appointments.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AppointmentExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
