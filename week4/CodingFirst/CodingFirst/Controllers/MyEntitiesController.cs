using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingFirst.Models;

namespace CodingFirst.Controllers
{
    public class MyEntitiesController : Controller
    {
        private CodeFirst db = new CodeFirst();

        // GET: MyEntities
        public ActionResult Index()
        {
            return View(db.MyEntities.ToList());
        }

        // GET: MyEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEntity myEntity = db.MyEntities.Find(id);
            if (myEntity == null)
            {
                return HttpNotFound();
            }
            return View(myEntity);
        }

        // GET: MyEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MyEntity myEntity)
        {
            if (ModelState.IsValid)
            {
                db.MyEntities.Add(myEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myEntity);
        }

        // GET: MyEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEntity myEntity = db.MyEntities.Find(id);
            if (myEntity == null)
            {
                return HttpNotFound();
            }
            return View(myEntity);
        }

        // POST: MyEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MyEntity myEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myEntity);
        }

        // GET: MyEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEntity myEntity = db.MyEntities.Find(id);
            if (myEntity == null)
            {
                return HttpNotFound();
            }
            return View(myEntity);
        }

        // POST: MyEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyEntity myEntity = db.MyEntities.Find(id);
            db.MyEntities.Remove(myEntity);
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
