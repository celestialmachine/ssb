using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ssb_api.Models
{
    public class BudgetEvent
    {
        [Key]
        public int EventId { get; set; }

        public int ItemId { get; set; }

        public BudgetItem? BudgetItem { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a name for the budget item.")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        [Range(-9999999999999999.99, 9999999999999999.99)]
        [Precision(18, 2)]
        public decimal Balance { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public string? Note { get; set; }
    }
}
