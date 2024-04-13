using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;

namespace Rally.Application.Dto
{
    public class EquipmentBaseDto : BaseDto
    {
        public byte[] Image { get; set; } = new byte[0];
    }
}