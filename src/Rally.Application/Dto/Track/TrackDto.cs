using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.Sign;

namespace Rally.Application.Dto.Track
{
    public class TrackDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;


        public CategoryDto? Category { get; private set; }
        public ICollection<SignDto> Signs { get; private set; }

        public TrackDto(string name, CategoryDto? category)
        {
            Name = name;
            Category = category;
        }
    }
}