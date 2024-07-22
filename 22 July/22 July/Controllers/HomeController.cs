using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _22_July.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipes()
        {
            ViewBag.Message = "Your Recipes description page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your About page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
        public ActionResult Donate()
        {
            ViewBag.Message = "Your Donate page.";

            return View();
        }
    }
}