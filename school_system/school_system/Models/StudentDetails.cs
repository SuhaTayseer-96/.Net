using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace school_system.Models
{
    public class StudentDetails
    {
        public int StudentDetailsId { get; set; }  // Primary Key
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Foreign Key 
        public int Id { get; set; }

        // Navigation property to reference the Student
        public virtual Students Student { get; set; }
    }
}