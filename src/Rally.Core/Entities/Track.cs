using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Account;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Track : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<Sign> Signs { get; set; } = new List<Sign>();
        public Category? Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public User User { get; set; } = default!;
        [ForeignKey("User")]
        public string UserId { get; set; } = default!;
    }
}