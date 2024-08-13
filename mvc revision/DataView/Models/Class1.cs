using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperProject.Models
{
    //2
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty ;
    }
}