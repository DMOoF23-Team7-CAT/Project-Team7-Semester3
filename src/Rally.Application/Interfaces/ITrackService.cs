using Rally.Application.Dto.Track;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ITrackService : IService<TrackDto, Track>
    {
        Task<TrackWithCategoryDto> GetTrackWithCategory(int trackId);
        Task<TrackWithSignsDto> GetTrackWithSigns(int trackId);
    }
}

