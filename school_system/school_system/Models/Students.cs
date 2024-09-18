using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace school_system.Models
{
    public class Students
    {
        public int Id { get; set; }
            //public Students() { }
        //public Students(int id) { }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; } // nullable here
        public virtual StudentDetails StudentDetails { get; set; }

    }
}