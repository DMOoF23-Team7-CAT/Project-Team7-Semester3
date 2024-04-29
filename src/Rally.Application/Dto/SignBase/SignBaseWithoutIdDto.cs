using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Application.Dto.SignBase
{
    public class SignBaseWithoutIdDto
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];
    }
}