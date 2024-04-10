using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Category.Dto;
using Rally.Application.Dto.Base;
using Rally.Application.Sign.Dto;

namespace Rally.Application.Track.Dto
{
    public class TrackDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;


        public CategoryDto? Category { get; set; }
        public ICollection<SignDto> Signs { get; set; } = new List<SignDto>();
    }
}