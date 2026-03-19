namespace FinTrackPro.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public double Amount { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^(Credit|Debit)$", ErrorMessage = "Category must be Credit or Debit.")]
        public required string Category { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }

}
