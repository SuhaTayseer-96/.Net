using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace codefirst.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; } // Primary Key
        public string ClassName { get; set; }

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}