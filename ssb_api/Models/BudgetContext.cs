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
                    ItemId = 1,
                    Date = DateTime.Now.AddDays(28),
                    DueDate = DateTime.Now.AddDays(28),
                    Balance = 100m,
                    Note = "Cell phone event note"
                }, new BudgetEvent
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(30),
                    DueDate = DateTime.Now.AddDays(30),
                    Balance = 200m,
                    Note = "This event has no item reference"
                });
        }
    }
}
