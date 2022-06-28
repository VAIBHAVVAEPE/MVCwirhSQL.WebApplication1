using Microsoft.AspNetCore.Mvc;
using MVCwirhSQL.WebApplication1.Models;
using System;
using Microsoft.AspNetCore.Http;
using MVCwirhSQL.Models;

namespace MVCwirhSQL.Controllers
{
    public class EmployeController : Controller
    {
        EmployeDAL context = new EmployeDAL();
        private object form;
        public IActionResult List()
        {
            ViewBag.EmployeList = context.GetAllEmployee();
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
            Employe E = new Employe();
            E.Emp_Name = from["Emp Name"];
            E.Dep_Name = from["Dep Name"];
            E.Emp_Salary = Convert.ToDecimal(from["Emp Salary"]);
            int res = context.Save(E);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employe  emp= context.GetProductById(id);
            ViewBag.Emp_Name = emp.Emp_Name;
            ViewBag.Dep_Name = emp.Dep_Name;
            ViewBag.Emp_Salary = emp.Emp_Name;
            ViewBag.Id = emp.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Employe emp = new Employe();
            emp.Emp_Name = form["Emp Name"];
            emp.Dep_Name = form["Dep Name"];
            emp.Emp_Salary = Convert.ToDecimal(form["Emp Salaey"]);
            emp.Id = Convert.ToInt32(form["id"]);
            int res = context.update(emp);
            if (res == 1)
            {
                return RedirectToAction("List");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employe emp = context.GetProductById(id);
            ViewBag.Emp_Name = emp.Emp_Name;
            ViewBag.Dep_Name = emp.Dep_Name;
            ViewBag.Emp_Salary = emp.Emp_Name;
            ViewBag.Id = emp.Id;
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
