using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace school_system.Models
{
    public class Assignments
    {
        public int Id { get; set; }
            public string Name { get; set; }
        public string SubjetDescription { get; set; }
    }
}