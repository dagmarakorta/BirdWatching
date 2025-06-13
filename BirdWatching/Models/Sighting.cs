namespace BirdWatching.Models
{
    public class Sighting
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public Bird Bird { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateOnly DateObserved { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public Uri PhotoUrl { get; set; }
        public ControlCenter ControlCenter { get; set; }
        public int ControlCenterId { get; set; }

    }
}
