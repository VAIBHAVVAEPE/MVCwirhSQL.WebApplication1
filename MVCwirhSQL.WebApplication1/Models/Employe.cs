using MVCwirhSQL.WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCwirhSQL.Models
{
    public class Employe
    {
        [key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Emp_Name { get; set; }
        public string Dep_Name { get; set; }
        public decimal Emp_Salary { get; set; }
    }
}