using codefirst.Models;
using codefirst.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codefirst.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["Username"] = user.Username;

                return RedirectToAction("About", "Home");
            }
            else
            {

                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Title = "About";
            var viewModel = new HomeViewModel
            {
                Classes = DbContext.Classes.ToList(),
                Subjects = DbContext.Subjects.ToList()
            };
            return View(viewModel);
        }

        public ActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClass(Class classModel)
        {
            if (ModelState.IsValid)
            {
                DbContext.Classes.Add(classModel);
                DbContext.SaveChanges();
                return RedirectToAction("About");
            }
            return View(classModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}