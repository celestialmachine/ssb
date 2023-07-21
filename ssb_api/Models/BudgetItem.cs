using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ssb_api.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the budget item.")]
        public string? Name { get; set; }

        public string? Description { get; set; } = null;

        public occurrence Occurrence { get; set; }

        [Range(0, 31, ErrorMessage = "Please enter a day of the week or day of the month.")]
        public int? OccurrenceDay { get; set; } = null;

        [Range(-9999999999999999.99, 9999999999999999.99)]
        [Precision(18,2)]
        public decimal Amount { get; set; } = 0;
    }

    public enum occurrence
    {
        None,
        Monthly,
        Weekly,
        BiWeekly
    }
}
