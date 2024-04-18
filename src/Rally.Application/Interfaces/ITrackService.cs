using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ITrackService : IService<TrackDto, Track>
    {
        Task<TrackDto> GetTrackWithCategory(int trackId);
        Task<TrackDto> GetTrackWithSigns(int trackId);
    }
}

