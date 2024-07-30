using _29_July___Task_6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _29_July___Task_6.Controllers
{
    public class ORCo4Controller : Controller
    {
        private CRUD_DATAEntities db = new CRUD_DATAEntities();
        // GET: ORCo4
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(users_CRUD User_, string confirmpassword)
        {
            if (User_.Password == confirmpassword) { 
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
        public ActionResult Login(users_CRUD User_) {


            var checkInput = db.users_CRUD.Where(model=> model.Email == User_.Email && model.Password == User_.Password).FirstOrDefault();


            Session["ID"] = checkInput.ID;
            if (checkInput != null)
            { 
            return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Profile()
        {
            var ID =(int)Session["ID"];
            var user = db.users_CRUD.Find(ID);
            return View(db.users_CRUD);
        }
        [HttpPost]
        public ActionResult Profile(users_CRUD User_)
        {
           db.Entry(User_).State = EntityState.Modified;
            db.SaveChanges();
            return View(db.users_CRUD);
        }

    }
}