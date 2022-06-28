using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwirhSQL.Models;
using System;

namespace MVCwirhSQL.Controllers
{

    public class CoursesController : Controller
    {
        CoursesDAL context = new CoursesDAL();
        public IActionResult List()
        {
            ViewBag.CoursesList = context.GetAllCoursess();
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
            Courses c = new Courses();
            c.Name = from["name"];
            c.Price = Convert.ToDecimal(from["Price"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Courses cour = context.GetCoursesById(id);
            ViewBag.Name = cour.Name;
            ViewBag.Price = cour.Price;
            ViewBag.Id = cour.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Courses cour = new Courses();
            cour.Name = form["name"];
            cour.Price = Convert.ToDecimal(form["price"]);
            cour.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(cour);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Courses cour = context.GetCoursesById(id);
            ViewBag.Name = cour.Name;
            ViewBag.Price = cour.Price;
            ViewBag.Id = cour.Id;
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
