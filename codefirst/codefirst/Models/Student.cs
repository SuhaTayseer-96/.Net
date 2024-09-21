using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codefirst.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } // Primary Key
        public string Name { get; set; }


        [ForeignKey("Class")]

        public int ClassId { get; set; } // Foreign Key

        // Navigation property
        public virtual Class Class { get; set; }
    }
}