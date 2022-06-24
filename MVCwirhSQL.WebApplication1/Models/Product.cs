using System.ComponentModel.DataAnnotations;

namespace MVCwirhSQL.WebApplication1.Models
{
    public class Product
    {
        [key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
