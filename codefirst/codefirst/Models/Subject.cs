using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace codefirst.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; } // Primary Key
        public string SubjectName { get; set; }
    }
}