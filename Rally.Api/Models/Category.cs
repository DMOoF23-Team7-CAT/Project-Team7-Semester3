using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Rules { get; set; } = string.Empty;
        public int NumberOfExercises { get; set; }

        [ForeignKey("CategoryType")]
        public int CategoryTypeId { get; set; }
        public CategoryType? Type { get; set; }
        public ICollection<Track>? Tracks { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}