using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Equipment : Entity
    {
        public byte[] Image { get; set; } = new byte[0];
        public ICollection<Exercise> Exercises { get; private set; }
        public ICollection<PositionedEquipment> PositionedEquipments { get; private set; }

        public Equipment()
        {
            Exercises = new List<Exercise>();
            PositionedEquipments = new List<PositionedEquipment>();
        }
    }
}