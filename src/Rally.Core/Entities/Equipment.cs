using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Equipment : Entity
    {
        public string Image { get; set; } = string.Empty;

        public ICollection<Exercise> Exercises { get; private set; }

        public Equipment()
        {
            Exercises = new List<Exercise>();
        }
    }
}