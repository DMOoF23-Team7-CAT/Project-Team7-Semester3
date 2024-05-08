using Rally.Application.Dto.Track;

namespace Rally.Application.Interfaces
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDto>> GetAll();
        Task<TrackDto> GetById(int id);
        Task<TrackDto> Create(CreateTrackDto dto);
        Task Update(TrackDto dto);
        Task Delete(int id);
        Task<TrackWithCategoryDto> GetTrackWithCategory(int trackId);
        Task<LoadTrackDto> LoadTrack(int trackId);
    }
}

