using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwirhSQL.WebApplication1.Models;

namespace MVCwirhSQL.WebApplication1.Controllers.Controllers
{
    public class ProductWithModelController : Controller
    {
        ProductDAL db = new ProductDAL();
        // GET: ProductWithModelController
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var Product = db.GetProductById(id);
            return View(Product);
        }

        // GET: ProductWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                db.Save(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Product prod = db.GetProductById(id);
            return View(prod);
        }

        // POST: ProductWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                db.update(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Product prod = db.GetProductById(id);
            return View(prod);
        }

        // POST: ProductWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                db.Delete(id); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
