using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersData.Models;

namespace UsersData.Controllers
{
    public class mvcearnController : Controller
    {
        private MVClearnEntities db = new MVClearnEntities();

        // GET: mvcearn
        public ActionResult Index()
        {
            return View(db.MVClearns.ToList());
        }
    }
}