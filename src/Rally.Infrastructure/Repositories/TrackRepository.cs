using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Exceptions;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Track> GetTrackWithSignsAsync(int trackId)
        {
            var spec = new TrackWithSignsSpecification(trackId);
            var track = (await GetAsync(spec)).FirstOrDefault();

            if (track is null)
                throw new InfrastructureException("Track not found");

            return track;
        }

        public async Task<Track> GetTrackWithCategoryAsync(int trackId)
        {
            var spec = new TrackWithCategorySpecification(trackId);
            var track = (await GetAsync(spec)).FirstOrDefault();

            if (track is null)
                throw new InfrastructureException("Track not found");

            return track;
        }
    }
}


