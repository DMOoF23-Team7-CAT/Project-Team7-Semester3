using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Application.Dto.Equipment
{
    public class CreateEquipmentDto
    {
        public string Image { get; set; } = string.Empty;

        public CreateEquipmentDto(string image)
        {
            Image = image;
        }
    }
}