using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Core.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;


        public Category? Category { get; set; }
        public ICollection<Sign> Signs { get; set; }

        public Track()
        {
            Signs = new List<Sign>();
        }
    }
}