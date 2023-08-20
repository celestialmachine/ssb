using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ssb_api.Models
{
    public class BudgetItem
    {
        public BudgetItem() => Events = new HashSet<BudgetEvent>();
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the budget item.")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public occurrence Occurrence { get; set; }

        [Range(0, 31, ErrorMessage = "Please enter a day of the week or day of the month.")]
        public int? OccurrenceDay { get; set; } = null;

        [Range(-9999999999999999.99, 9999999999999999.99)]
        [Precision(18,2)]
        public decimal Amount { get; set; } = 0;

        [InverseProperty("BudgetItem")]
        public ICollection<BudgetEvent> Events { get; set;}
    }

    public enum occurrence
    {
        None,
        Monthly,
        Weekly,
        BiWeekly
    }
}
