namespace Rally.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public User? User { get; set; }
        public Category? Category { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }

    }
}