using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codefirst.Models;

namespace codefirst.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        // List all subjects
        public ActionResult Index()
        {
            var subjects = DbContext.Subjects.ToList();
            return View(subjects);
        }

        // Create Subject
        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject model)
        {
            if (ModelState.IsValid)
            {
                DbContext.Subjects.Add(model);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete Subject
        public ActionResult DeleteSubject(int id)
        {
            var subject = DbContext.Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (subject != null)
            {
                DbContext.Subjects.Remove(subject);
                DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
