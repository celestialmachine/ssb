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
                    Id = 1,
                    Name = "Utility",
                    Occurrence = occurrence.None
                },
                new BudgetItem
                {
                    Id = 2,
                    Name = "Rent",
                    Description = "Level 9000 Apartments",
                    Occurrence = occurrence.Monthly,
                    OccurrenceDay = 1,
                    Amount = 1500m
                }, new BudgetItem
                {
                    Id = 3,
                    Name = "Gas",
                    Description = "Chell or Chevron",
                    Occurrence = occurrence.Weekly,
                    OccurrenceDay = 4,
                    Amount = 40m
                }, new BudgetItem
                {
                    Id = 4,
                    Name = "Cell Phone",
                    Description = "T-Mobile Family Plan",
                    Occurrence = occurrence.Monthly,
                    OccurrenceDay = 15,
                    Amount = 100m
                }
            );

            modelBuilder.Entity<BudgetEvent>().HasData(
                new BudgetEvent
                {
                    Id = 1,
                    ItemId = 4,
                    Name = "Cell Phone - September 2023",
                    Description = "T-Mobile Family Plan",
                    Date = DateTime.Now.AddDays(28),
                    DueDate = DateTime.Now.AddDays(28),
                    Balance = 100m,
                    Note = "Cell phone event note"
                }, new BudgetEvent
                {
                    Id = 2,
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
