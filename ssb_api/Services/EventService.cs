using ssb_api.Models;

namespace ssb_api.Services
{
    public class EventService
    {
        private const int BudgetScope = 60;

        private readonly BudgetContext _context;
        public EventService(BudgetContext context)
        {
            _context = context;
        }

        public async Task genereateAsync(BudgetItem item)
        {
            var events = new List<BudgetEvent>();
            switch (item.Occurrence)
            {
                case occurrence.None:
                    //add single event today's date
                    events.Add(createEvent(DateTime.Now, item));
                    break;
                case occurrence.Monthly:
                    //add event for current month plus next month
                    events.Add(createEvent(DateTime.Now, item));
                    events.Add(createEvent(DateTime.Now.AddMonths(1), item));
                    break;
                case occurrence.Weekly:
                    //add event for current week plus 60 days
                    if (item.OccurrenceDay != null)
                    {
                        int daysToAdd = (int)item.OccurrenceDay;
                        DateTime startDate = getNextWeekday(DateTime.Now, daysToAdd);
                        for (int i = 0; i < BudgetScope; i+= 7)
                        {
                            events.Add(createEvent(startDate.AddDays(i), item));
                        }
                    }
                    else
                    {
                        //TODO return or log an error
                        break;
                    }
                    break;
                case occurrence.BiWeekly:
                    //add event for current week plus 60 days
                    if (item.OccurrenceDay != null)
                    {
                        int daysToAdd = (int)item.OccurrenceDay;
                        DateTime startDate = getNextWeekday(DateTime.Now, daysToAdd);
                        for (int i = 0; i < BudgetScope; i += 14)
                        {
                            events.Add(createEvent(startDate.AddDays(i), item));
                        }
                    }
                    else
                    {
                        //TODO return or log an error
                        break;
                    }
                    break;
                default:
                    //TODO return or log an error
                    break;
            }
            _context.BudgetEvents.AddRange(events);
            await _context.SaveChangesAsync();
        }

        private BudgetEvent createEvent(DateTime date, BudgetItem item)
        {
            BudgetEvent newEvent = new BudgetEvent()
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Description = item.Description,
                Date = date,
                DueDate = date,
                Balance = item.Amount,
                IsPaid = false,
                Note = ""
            };
            return newEvent;
        }

        private DateTime getNextWeekday(DateTime date, int day)
        {
            int daysToAdd = (day - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysToAdd);
        }
    }
}
