using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwirhSQL.WebApplication1.Models;
using System;

namespace MVCwirhSQL.WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        private object form;

        public IActionResult List()
        {
            ViewBag.ProductList = context.GetAllProducts();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection from)
        {
            Product p = new Product();
            p.Name = from["Name"];
            p.Price = Convert.ToDecimal(from["Price"]);
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Peice = prod.Price;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Product prod = new Product();
            prod.Name = form["name"];
            prod.Price = Convert.ToDecimal(form["Price"]);
            prod.Id = Convert.ToInt32(form["id"]);
            int res = context.update(prod);
            if (res == 1)
                return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Peice = prod.Price;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }

    }
}
