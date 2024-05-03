using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<Track> GetTrackWithSignsAsync(int trackId);
        Task<Track> GetTrackWithCategoryAsync(int trackId);
    }
}

