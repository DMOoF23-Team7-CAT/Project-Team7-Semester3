using Rally.Application.Dto.Track;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ITrackService : IService<TrackDto, Track, TrackWithoutIdDto>
    {
        Task<TrackWithCategoryDto> GetTrackWithCategory(int trackId);
        Task<TrackWithSignsDto> GetTrackWithSigns(int trackId);
        Task<TrackDto> CreateTrackWithUser(TrackDto trackDto);
        Task<LoadTrackDto> LoadTrack(int trackId);
    }
}

