using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _29_July_Crud_Task.Models;
using Microsoft.Ajax.Utilities;

namespace _29_July_Crud_Task.Controllers
{
    public class users_CRUDController : Controller
    {
        private CRUD_DATAEntities db = new CRUD_DATAEntities();

        // GET: users_CRUD
        public ActionResult HomePage()
        {
            return View(db.users_CRUD.ToList());
        }

        // GET: users_CRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_CRUD users_CRUD = db.users_CRUD.Find(id);
            if (users_CRUD == null)
            {
                return HttpNotFound();
            }
            return View(users_CRUD);
        }

        // GET: users_CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users_CRUD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Password,Image")] users_CRUD users_CRUD)
        {
            if (ModelState.IsValid)
            {
                db.users_CRUD.Add(users_CRUD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users_CRUD);
        }

        // GET: users_CRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_CRUD users_CRUD = db.users_CRUD.Find(id);
            if (users_CRUD == null)
            {
                return HttpNotFound();
            }
            return View(users_CRUD);
        }

        // POST: users_CRUD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password,Image")] users_CRUD users_CRUD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users_CRUD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users_CRUD);
        }

        // GET: users_CRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_CRUD users_CRUD = db.users_CRUD.Find(id);
            if (users_CRUD == null)
            {
                return HttpNotFound();
            }
            return View(users_CRUD);
        }

        // POST: users_CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users_CRUD users_CRUD = db.users_CRUD.Find(id);
            db.users_CRUD.Remove(users_CRUD);
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

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(users_CRUD users, string ConfirmPassword)
        {
            if (users.Password == ConfirmPassword)
            {
                db.users_CRUD.Add(users);
                db.SaveChanges();
                return RedirectToAction("HomePage");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users_CRUD users)
        {
            var checkInput = db.users_CRUD.Where(model => model.Email == users.Email && model.Password == users.Password).FirstOrDefault();

            Session("User_ID") = checkInput.ID;


            if (checkInput != null)
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session("User_ID") = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            var userID = (int)Session["User_ID"];
            var user = db.users_CRUD.Find(userID);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(users_CRUD users, HttpPostedFileBase upload)
        {

            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);

                if (!Directory.Exists(Server.MapPath("~/Image/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Image/"));


                }
                Var path = Path.Combine(Server.MapPath("~/Image/"), fileName);

                upload.SaveAs(path);

                users.Image = fileName;
            }
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Profile");
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string ConfirmPassowrd)
        {
            var userID = (int)Session["User_ID"];
            var user = db.users_CRUD.Find(userID);
            if (currentPassword == user.Password)
            {
                if (newPassword == ConfirmPassowrd) { }
            }
            user.Password = newPassword;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Profile");
        }
        else
        {
        ViewBag.Message = "Doesn't match";
            return ViewContext(user);
    } 
    else{
    ViewBag.Message = "incorrect";
        return ViewContext(user);
}        

}
