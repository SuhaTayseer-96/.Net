using System.Web.Mvc;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        [HttpPost]
        public ActionResult Contact(string name, int age, string gender, string education, string[] hobbies)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Gender = gender;
            ViewBag.Education = education;
            ViewBag.Hobbies = hobbies;

            return View("DisplayContact");
        }

        // GET: Home/DisplayContact [overloading]
        public ActionResult DisplayContact()
        {
            return View();
        }
        public ActionResult Page3()
        {
            return View();
        }
    }
}
