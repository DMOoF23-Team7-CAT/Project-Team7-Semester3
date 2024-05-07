using System.ComponentModel.DataAnnotations.Schema;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Equipment : Entity
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public EquipmentBase? EquipmentBase { get; set; }
        [ForeignKey("EquipmentBase")]
        public int EquipmentBaseId { get; set; }
        public Sign? Sign { get; set; }
        [ForeignKey("Sign")]
        public int SignId { get; set; }
    }
}

