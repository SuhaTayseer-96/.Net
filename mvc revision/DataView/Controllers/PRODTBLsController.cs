using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class PRODTBLsController : Controller
    {
        private ProductsssEntities db = new ProductsssEntities();

        // GET: PRODTBLs
        public ActionResult Index()
        {
            return View(db.PRODTBLs.ToList());
        }

        // GET: PRODTBLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODTBL pRODTBL = db.PRODTBLs.Find(id);
            if (pRODTBL == null)
            {
                return HttpNotFound();
            }
            return View(pRODTBL);
        }

        // GET: PRODTBLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODTBLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdID,Name,Price,Description")] PRODTBL pRODTBL)
        {
            if (ModelState.IsValid)
            {
                db.PRODTBLs.Add(pRODTBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODTBL);
        }

        // GET: PRODTBLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODTBL pRODTBL = db.PRODTBLs.Find(id);
            if (pRODTBL == null)
            {
                return HttpNotFound();
            }
            return View(pRODTBL);
        }

        // POST: PRODTBLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdID,Name,Price,Description")] PRODTBL pRODTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODTBL);
        }

        // GET: PRODTBLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODTBL pRODTBL = db.PRODTBLs.Find(id);
            if (pRODTBL == null)
            {
                return HttpNotFound();
            }
            return View(pRODTBL);
        }

        // POST: PRODTBLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODTBL pRODTBL = db.PRODTBLs.Find(id);
            db.PRODTBLs.Remove(pRODTBL);
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
