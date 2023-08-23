using Microsoft.EntityFrameworkCore;

namespace ssb_api.Models
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options) { }

        public DbSet<BudgetItem> BudgetItems { get; set; } = null!;
        public DbSet<BudgetEvent> BudgetEvents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BudgetItem>().HasData(
                new BudgetItem
                {
                    ItemId = 1,
                    Name = "Utility",
                    Occurrence = occurrence.None
                },
                new BudgetItem
                {
                    ItemId = 2,
                    Name = "Rent",
                    Description = "Level 9000 Apartments",
                    Occurrence = occurrence.Monthly,
                    OccurrenceDay = 1,
                    Amount = 1500m
                }
            );

            modelBuilder.Entity<BudgetEvent>().HasData(
                new BudgetEvent
                {
                    EventId = 2,
                    ItemId = 1,
                    Name = "School books Fall 23",
                    Date = DateTime.Now.AddDays(30),
                    DueDate = DateTime.Now.AddDays(30),
                    Balance = 200m,
                    Note = "This event has no item reference"
                });
        }
    }
}
