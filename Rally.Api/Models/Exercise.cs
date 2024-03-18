using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public int SignNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        [ForeignKey("ExerciseType")]
        public int ExerciseTypeId { get; set; }
        public ExerciseType? ExerciseType { get; set; }
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}