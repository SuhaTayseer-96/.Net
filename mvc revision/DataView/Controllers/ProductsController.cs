using DapperProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();

        }


        //1
        //[HttpPost]
        //public ActionResult Product(string ProductName, string Image)
        //{
        //    Session["ProductName"] = ProductName;
        //    Session["Image"] = Image;
        //    return RedirectToAction("Index");
        //}
        //2
        //[HttpPost]
        //public ActionResult Product(string ProductName, string Image)
        //{
        //    if (Session["porducts"] == null)
        //    {
        //        Session["porducts"] = new List<Product>();
        //    }
        //    var product = new Product();
        //    product.Name = ProductName;
        //    product.ImageUrl = Image;
        //    var porducts = Session["porducts"] as List<Product>;
        //    porducts.Add(product);
        //    Session["porducts"] = porducts;

        //    return RedirectToAction("Index");
        //}
        public ActionResult Admin()
        {
            return View();
        }

    }
}