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
    public class ClassController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        // List all classes
        public ActionResult Index()
        {
            var classes = DbContext.Classes.Include(c => c.Students).Include(c => c.Assignments).ToList();
            return View(classes);
        }

        // Create Class
        [HttpGet]
        public ActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClass(Class model)
        {
            if (ModelState.IsValid)
            {
                DbContext.Classes.Add(model);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete Class (with confirmation)
        [HttpGet]
        public ActionResult DeleteClass(int id)
        {
            var classToDelete = DbContext.Classes.Include(c => c.Students).Include(c => c.Assignments).FirstOrDefault(c => c.ClassId == id);
            if (classToDelete == null)
            {
                return HttpNotFound();
            }
            return View(classToDelete);
        }

        [HttpPost]
        public ActionResult ConfirmDeleteClass(int id)
        {
            var classToDelete = DbContext.Classes.Include(c => c.Students).Include(c => c.Assignments).FirstOrDefault(c => c.ClassId == id);
            if (classToDelete != null)
            {
                DbContext.Classes.Remove(classToDelete);
                DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Add Students List
        public ActionResult AddStudentsList(int id)
        {
            var classModel = DbContext.Classes.FirstOrDefault(c => c.ClassId == id);
            return View(classModel);
        }

        // Add Tasks List (similar to Students)
        public ActionResult AddTasksList(int id)
        {
            var classModel = DbContext.Classes.FirstOrDefault(c => c.ClassId == id);
            return View(classModel);
        }
    }

}
