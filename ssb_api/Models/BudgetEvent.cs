namespace ssb_api.Models
{
    public class BudgetEvent
    {
        public int Id { get; set; }

        public BudgetItem? BudgetItem { get; set; }

        public DateTime? Date { get; set; }

        public decimal Balance { get; set; } = 0;

        public bool IsPaid { get; set; }

        public string? Note { get; set; }
    }
}
