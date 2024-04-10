using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;

namespace Rally.Application.Equipment.Dto
{
    public class EquipmentDto : BaseDto
    {
        public string Image { get; set; } = string.Empty;

        public EquipmentDto(string image)
        {
            Image = image;
        }
    }
}