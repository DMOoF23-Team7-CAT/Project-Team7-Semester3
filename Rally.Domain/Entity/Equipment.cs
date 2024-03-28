using System;
using System.Collections.Generic;

namespace Rally.Domain.Entity
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;

        public ICollection<Exercise>? Exercises { get; set; }
    }
}