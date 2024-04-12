using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.Exercise;
using Rally.Application.Dto.Track;

namespace Rally.Application.Dto.Sign
{
    public class SignDto : BaseDto
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        public ExerciseDto? Exercise { get; private set; }
        public TrackDto? Track { get; private set; }

        public SignDto(string xCoordinate, string yCoordinate,
        ExerciseDto exercise, TrackDto track)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Exercise = exercise;
            Track = track;
        }
    }
}