namespace TechAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Category { get; set; } = "";
        public string ModelNumber { get; set; } = "";
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string RAM { get; set; } = "";
        public string Storage { get; set; } = "";
        public string Color { get; set; } = "";
        public string Warranty { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "";
    }
}