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
    public class BatchController : Controller
    {
        private db_smsEntities db = new db_smsEntities();

        // GET: Batch
        public ActionResult Index()
        {
            return View(db.tb_batch.ToList());
        }

        // GET: Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_batch tb_batch = db.tb_batch.Find(id);
            if (tb_batch == null)
            {
                return HttpNotFound();
            }
            return View(tb_batch);
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,batch,year")] tb_batch tb_batch)
        {
            if (ModelState.IsValid)
            {
                db.tb_batch.Add(tb_batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_batch);
        }

        // GET: Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_batch tb_batch = db.tb_batch.Find(id);
            if (tb_batch == null)
            {
                return HttpNotFound();
            }
            return View(tb_batch);
        }

        // POST: Batch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,batch,year")] tb_batch tb_batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_batch);
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_batch tb_batch = db.tb_batch.Find(id);
            if (tb_batch == null)
            {
                return HttpNotFound();
            }
            return View(tb_batch);
        }

        // POST: Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_batch tb_batch = db.tb_batch.Find(id);
            db.tb_batch.Remove(tb_batch);
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
