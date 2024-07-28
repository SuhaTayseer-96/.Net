using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UsersData.Models;

namespace UsersData.Controllers
{
    public class MVClearnsController : Controller
    {
        private MVClearnEntities db = new MVClearnEntities();

        // GET: MVClearns
        public ActionResult Index()
        {
            return View(db.MVClearns.ToList());
        }

        // GET: MVClearns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVClearn mVClearn = db.MVClearns.Find(id);
            if (mVClearn == null)
            {
                return HttpNotFound();
            }
            return View(mVClearn);
        }

        // GET: MVClearns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVClearns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,Image")] MVClearn mVClearn)
        {
            if (ModelState.IsValid)
            {
                db.MVClearns.Add(mVClearn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVClearn);
        }

        // GET: MVClearns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVClearn mVClearn = db.MVClearns.Find(id);
            if (mVClearn == null)
            {
                return HttpNotFound();
            }
            return View(mVClearn);
        }

        // POST: MVClearns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password,Image")] MVClearn mVClearn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVClearn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVClearn);
        }

        // GET: MVClearns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVClearn mVClearn = db.MVClearns.Find(id);
            if (mVClearn == null)
            {
                return HttpNotFound();
            }
            return View(mVClearn);
        }

        // POST: MVClearns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVClearn mVClearn = db.MVClearns.Find(id);
            db.MVClearns.Remove(mVClearn);
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
        //public ActionResult GetImage(int id)
        //{
        //    var product = db.MVClearns.Find(id);
        //    if (product != null && product.Image != null)
        //    {
        //        return File(product.Image, "image/jpg");
        //    }
        //    return null;
        //}
    }
}


