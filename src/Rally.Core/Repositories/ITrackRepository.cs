using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<Track> GetTrackWithCategoryAsync(int trackId);
        Task<Track> LoadTrackAsync(int trackId);
    }
}

