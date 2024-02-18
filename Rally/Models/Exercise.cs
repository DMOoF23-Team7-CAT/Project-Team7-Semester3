using System.ComponentModel.DataAnnotations.Schema;

namespace Rally.Models
{
    public enum ExerciseType
    {
        
    }
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? SignNumber { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public string? Rotation { get; set; }
        public ICollection<Category>? Category { get; set; }
        public ICollection<Track>? Track { get; set; }
        public ExerciseType? Type { get; set; }
        public Equipment? Equipment { get; set; }

    }
}