using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CourseController : Controller
    {
        private db_smsEntities db = new db_smsEntities();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.tb_course.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_course tb_course = db.tb_course.Find(id);
            if (tb_course == null)
            {
                return HttpNotFound();
            }
            return View(tb_course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,course,duration")] tb_course tb_course)
        {
            if (ModelState.IsValid)
            {
                db.tb_course.Add(tb_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_course tb_course = db.tb_course.Find(id);
            if (tb_course == null)
            {
                return HttpNotFound();
            }
            return View(tb_course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,course,duration")] tb_course tb_course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_course tb_course = db.tb_course.Find(id);
            if (tb_course == null)
            {
                return HttpNotFound();
            }
            return View(tb_course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_course tb_course = db.tb_course.Find(id);
            db.tb_course.Remove(tb_course);
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
