using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Api.Models;

namespace Rally.Api.Dtos.Category
{
    public class GetAllTracksInCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Track>? Tracks { get; set; }
    }
}