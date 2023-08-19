using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ssb_api.Models
{
    public class BudgetEvent
    {
        public int Id { get; set; }

        public int? ItemId { get; set; }

        [ValidateNever]
        public BudgetItem? BudgetItem { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        [Range(-9999999999999999.99, 9999999999999999.99)]
        [Precision(18, 2)]
        public decimal Balance { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public string? Note { get; set; }
    }
}
