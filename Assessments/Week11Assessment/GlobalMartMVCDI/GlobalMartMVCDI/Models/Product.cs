namespace GlobalMartMVCDI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = "High-quality product from GlobalMart.";
    }
}
