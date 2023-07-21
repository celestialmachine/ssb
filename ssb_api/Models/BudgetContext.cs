using Microsoft.EntityFrameworkCore;

namespace ssb_api.Models
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options) { }

        public DbSet<BudgetItem> BudgetItems { get; set; } = null!;

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
        }
    }
}
