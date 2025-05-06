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
    public class RegistrationController : Controller
    {
        private db_smsEntities db = new db_smsEntities();

        // GET: Registration
        public ActionResult Index()
        {
            var tb_registration = db.tb_registration.Include(t => t.tb_batch).Include(t => t.tb_course);
            return View(tb_registration.ToList());
        }

        // GET: Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_registration tb_registration = db.tb_registration.Find(id);
            if (tb_registration == null)
            {
                return HttpNotFound();
            }
            return View(tb_registration);
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.tb_batch, "id", "batch");
            ViewBag.course_id = new SelectList(db.tb_course, "id", "course");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] tb_registration tb_registration)
        {
            if (ModelState.IsValid)
            {
                db.tb_registration.Add(tb_registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.tb_batch, "id", "batch", tb_registration.batch_id);
            ViewBag.course_id = new SelectList(db.tb_course, "id", "course", tb_registration.course_id);
            return View(tb_registration);
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_registration tb_registration = db.tb_registration.Find(id);
            if (tb_registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.tb_batch, "id", "batch", tb_registration.batch_id);
            ViewBag.course_id = new SelectList(db.tb_course, "id", "course", tb_registration.course_id);
            return View(tb_registration);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] tb_registration tb_registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.tb_batch, "id", "batch", tb_registration.batch_id);
            ViewBag.course_id = new SelectList(db.tb_course, "id", "course", tb_registration.course_id);
            return View(tb_registration);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_registration tb_registration = db.tb_registration.Find(id);
            if (tb_registration == null)
            {
                return HttpNotFound();
            }
            return View(tb_registration);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_registration tb_registration = db.tb_registration.Find(id);
            db.tb_registration.Remove(tb_registration);
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
