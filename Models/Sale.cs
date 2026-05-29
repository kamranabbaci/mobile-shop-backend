namespace TechAPI.Models
{
    public class Sale
    {
        public int SaleID { get; set; }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = "";

        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime SaleDate { get; set; }
    }
}