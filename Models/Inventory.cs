namespace TechAPI.Models
{
    public class Inventory
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int StockAvailable { get; set; }
        public int ReorderStock { get; set; }
    }
}
