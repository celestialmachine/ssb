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
                    if(item.OccurrenceDay != null)
                    {
                        events.Add(createEvent(getNextCalendarDay((int)item.OccurrenceDay), item));
                        events.Add(createEvent(getNextCalendarDay((int)item.OccurrenceDay).AddMonths(1), item));
                    }
                    else
                    {
                        //TODO handle error
                        break;
                    }
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
                        //TODO handle error
                        break;
                    }
                    break;
                case occurrence.BiWeekly:
                    //add event for current week plus 60 days, biweekly
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
                        //TODO handle error
                        break;
                    }
                    break;
                default:
                    //TODO return or log error
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

        private DateTime getNextCalendarDay(int day)
        {
            //check if day is present or future in current month
            if(day >= DateTime.Now.Day)
            {
                //return current month, replace day with day
                try
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    //return last day of month
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                }
            }
            else
            {
                //Return next month, replace day with day
                try
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    //return last day of month
                    //TODO fix issue with not returning correct last day based on occurrence, might have to change parameter
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1));
                }
            }
        }

        private DateTime getNextWeekday(DateTime date, int day)
        {
            int daysToAdd = (day - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysToAdd);
        }
    }
}
