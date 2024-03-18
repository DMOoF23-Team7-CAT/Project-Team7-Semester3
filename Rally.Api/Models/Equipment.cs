using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }
        public EquipmentType? Type { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}