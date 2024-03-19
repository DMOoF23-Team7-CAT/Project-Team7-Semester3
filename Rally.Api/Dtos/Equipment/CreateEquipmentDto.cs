using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Api.Dtos.Exercise;

namespace Rally.Api.Dtos.Equipment
{
    public class CreateEquipmentDto
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}