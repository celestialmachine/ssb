using ssb_api.Models;

namespace ssb_api.Services
{
    public class EventService
    {
        private readonly BudgetContext _context;
        public EventService(BudgetContext context)
        {
            _context = context;
        }

        public void genereate(BudgetItem item)
        {
            var events = new List<BudgetEvent>();
            switch (item.Occurrence)
            {
                case occurrence.None:
                    BudgetEvent budgetEvent = new BudgetEvent()
                    {
                        ItemId = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        Balance = item.Amount,
                        IsPaid = false,
                        Note = ""
                    };
                    events.Add(budgetEvent);
                    break;
                case occurrence.Monthly:
                    //add event for current month plus next month
                    break;
                case occurrence.Weekly:
                    //add event for current week plus 60 days
                    break;
                case occurrence.BiWeekly:
                    //add event for current week plus 60 days
                    break;
                default:
                    break;
            }
            _context.BudgetEvents.AddRange(events);
            _context.SaveChanges();
        }
    }
}
