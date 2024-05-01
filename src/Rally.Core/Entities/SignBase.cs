using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class SignBase : Entity
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];

        public EquipmentBase? EquipmentBase { get; set; }
        [ForeignKey("EquipmentBase")]
        public int EquipmentBaseId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public ICollection<Sign> Signs { get; set; } = new List<Sign>();
    }
}