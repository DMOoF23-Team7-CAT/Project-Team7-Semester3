namespace Rally.Models
{
    public enum CategoryType
    {
        Beginner,
        Advanced,
        Expert,
        Champion,
        Open
    }
    public class Category
    {
        public int Id { get; set; }
        public CategoryType? Type { get; set; }
        public string? Rules { get; set; }
        public int NumberOfExercises { get; set; }
        public ICollection<Track>? Tracks { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }


    }
}