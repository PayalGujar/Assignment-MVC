using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


public class ProductController : Controller
{
    public ActionResult Index()
    {
        
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Pen", Price = 20 },
            new Product { Id = 2, Name = "Pencil", Price =10 },
            new Product { Id = 3, Name = "Eraser", Price =2 }
        };

        
        ViewData["Message"] = "This is the product list";

        
        ViewBag.Products = products;

        return View();
    }
}