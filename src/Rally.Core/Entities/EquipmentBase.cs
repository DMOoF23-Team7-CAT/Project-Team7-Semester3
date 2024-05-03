using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class EquipmentBase : Entity
    {
        public byte[] Image { get; set; } = new byte[0];
        public ICollection<SignBase> SignBases { get; set; } = new List<SignBase>();
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}