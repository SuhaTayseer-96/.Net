using school_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace school_system.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,FirstName,LastName,DateOfBirth")] Students student)
        {
            if (ModelState.IsValid)
            {
                var studentDetails = new StudentDetails
                {
                    Address = "123 Main St",
                    DateOfBirth = student.DateOfBirth.Value,
                    Student = student
                };

                db.Students.Add(student);
                db.StudentDetails.Add(studentDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // Add Edit, Delete, and Details actions similarly
    }

}