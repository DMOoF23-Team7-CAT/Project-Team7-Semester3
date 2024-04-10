using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Exercise.Dto;
using Rally.Application.Track.Dto;

namespace Rally.Application.Sign.Dto
{
    public class SignDto : BaseDto
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        public ExerciseDto? Exercise { get; set; }
        public TrackDto? Track { get; set; }
    }
}