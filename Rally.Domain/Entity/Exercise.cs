using System;
using System.Collections.Generic;

namespace Rally.Domain.Entity
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public Equipment? Equipment { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}