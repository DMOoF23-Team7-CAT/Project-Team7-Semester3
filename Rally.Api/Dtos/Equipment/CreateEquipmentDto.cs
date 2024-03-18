using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Dtos.Equipment
{
    public class CreateEquipmentDto
    {
        public string Image { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int EquipmentTypeId { get; set; }
    }
}