using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.Category
{
    public class CategoryWithoutIdDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;
    }
}