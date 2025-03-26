using System.ComponentModel.DataAnnotations;

namespace Product_Management_Dashboard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
