using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Application.Dto.EquipmentBase
{
    public class CreateEquipmentBaseDto
    {
        public byte[] Image { get; set; } = new byte[0];

        public CreateEquipmentBaseDto(byte[] image)
        {
            Image = image;
        }
    }
}