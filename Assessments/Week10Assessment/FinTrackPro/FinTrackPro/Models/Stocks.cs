namespace FinTrackPro.Models
{
    public class Stocks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
