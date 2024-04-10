using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Exercise : Entity
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];

        public EquipmentBase? EquipmentBase { get; set; }
        public Category? Category { get; set; }
        public ICollection<Sign> Signs { get; private set; }

        public Exercise()
        {
            Signs = new List<Sign>();
        }
    }
}