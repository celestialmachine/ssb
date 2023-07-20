namespace ssb_api.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public Occurence Occurence { get; set; }
    }

    public enum Occurence
    {
        Monthly,
        Weekly,
        BiWeekly
    }
}
