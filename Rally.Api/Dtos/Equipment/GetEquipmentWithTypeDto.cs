using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Api.Models;

namespace Rally.Api.Dtos.Equipment
{
    public class GetEquipmentWithTypeDto
    {
        public string Image { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public EquipmentType? Type { get; set; }
    }
}