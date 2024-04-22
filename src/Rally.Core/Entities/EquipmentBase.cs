using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class EquipmentBase : Entity
    {
        public byte[] Image { get; set; } = new byte[0];
        public ICollection<SignBase> SignBases { get; private set; }
        public ICollection<Equipment> Equipments { get; private set; }

        public EquipmentBase()
        {
            SignBases = new List<SignBase>();
            Equipments = new List<Equipment>();
        }
    }
}