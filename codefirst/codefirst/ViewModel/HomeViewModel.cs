using codefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codefirst.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}