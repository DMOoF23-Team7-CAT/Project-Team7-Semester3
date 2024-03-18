using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Api.Models;

namespace Rally.Api.Dtos.Category
{
    public class GetCategoryDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;
        public int NumberOfExercises { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}