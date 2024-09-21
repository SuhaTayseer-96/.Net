using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codefirst.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; }
    }
}