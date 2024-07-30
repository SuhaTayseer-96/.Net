using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using Updated_CRUD_TASK.Models;

namespace Updated_CRUD_TASK.Controllers
{
    public class users_CRUDController : Controller
    {
        private CRUD_DATAEntities db = new CRUD_DATAEntities();

        // GET: users_CRUD
        public ActionResult Index()
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

        // POST
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
        public ActionResult Register(users_CRUD User_, string ConirmPasssword)
        {
            if (User_.Password == ConirmPasssword)
            {
                db.users_CRUD.Add(User_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Login(string inputEmail, string inputPassword)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(users_CRUD User_)
        {


            var checkInput = db.users_CRUD.FirstOrDefault(model => model.Email == User_.Email && model.Password == User_.Password); 


            Session["ID"] = checkInput.ID;
            if (checkInput != null)
            {
                HttpCookie CheckCookies = new HttpCookie("CheckkingCookies");
                CheckCookies.Value = User_.Email;
                CheckCookies.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(CheckCookies);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Profile()
        {
            var cookie = Request.Cookies["CheckkingCookies"];
            if (cookie == null) 
            {
            return RedirectToAction("Login");
            } 

            var Email = cookie.Value;
            var data = db.users_CRUD.FirstOrDefault(em => em.Email == Email);
            if (Email == null)
            {
                return HttpNotFound();
            }

            var model = new users_CRUD
            {
                Name = data.Name,
                Email = data.Email,
                Image = data.Image,
            };

            return View(model);
        }

        public ActionResult EditProfile()
        {
            var cookie = Request.Cookies["CheckkingCookies"];
            if (cookie == null)
            {
                return RedirectToAction("Login");
            }

            var Email = cookie.Value;
            var data = db.users_CRUD.FirstOrDefault(em => em.Email == Email);
            if (Email == null)
            {
                return HttpNotFound();
            }

            var model = new users_CRUD
            {
                Name = data.Name,
                Email = data.Email,
                Image = data.Image,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(users_CRUD user, HttpPostedFileBase img)
        {
            var cookie = Request.Cookies["CheckkingCookies"];
            if (cookie == null)
            {
                return RedirectToAction("Login");
            }

            var email = cookie.Value;
            var data = db.users_CRUD.FirstOrDefault(em => em.Email == email);

            if (data == null)
            {
                return HttpNotFound();
            }

            user.Name = data.Name;
            user.Email = data.Email;
            user.Image = data.Image;
     

            // Handle image upload
            if (img != null && img.ContentLength > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(img.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Only image files are allowed.");
                    return View(user);
                }

                if (img.ContentLength > 1048576) // 1MB
                {
                    ModelState.AddModelError("", "File size cannot exceed 1MB.");
                    return View(user);
                }

                var fileName = Path.GetFileName(img.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                img.SaveAs(path);
                user.Image = "/Images/" + fileName;
            }

            try
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        ModelState.AddModelError("", $"{validationErrors.Entry.Entity.GetType().Name}: {validationError.ErrorMessage}");
                    }
                }
                return View(user);
            }
        }
    }
}
