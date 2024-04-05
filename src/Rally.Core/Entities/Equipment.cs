using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Core.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;

        public ICollection<Exercise> Exercises { get; set; }

        public Equipment()
        {
            Exercises = new List<Exercise>();
        }
    }
}