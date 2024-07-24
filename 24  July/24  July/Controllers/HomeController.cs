using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24__July.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
            [HttpPost]

            public ActionResult Contact(FormCollection form)
            {
                // Process the input data
                ViewBag.email = form["email"];
                ViewBag.fullname = form["fullname"];
                ViewBag.message = form["message"];
            
                return View();
            }

        public ActionResult login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }
        [HttpPost]
        public ActionResult login(string email, string password)
        {
            if (email == "ss.ss@gmail.com" && password == "159951")
            {
                Session["login"] = true;
                Session["username"] = email; // Save the username in the session
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Invalid credentials. Please try again.";
            return View("index");

        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}



