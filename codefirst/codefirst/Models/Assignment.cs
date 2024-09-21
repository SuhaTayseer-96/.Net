using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codefirst.Models
{
    public class Assignment
    {
        [Key]
        public int AssignId { get; set; } // Primary Key
        public string AssignName { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; } // Foreign Key

        // Navigation property
        public virtual Class Class { get; set; }
    }
}