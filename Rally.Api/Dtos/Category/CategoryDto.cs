using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;
    }
}