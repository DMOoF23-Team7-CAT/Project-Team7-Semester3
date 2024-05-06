using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;
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
            var track = await _dbContext.Set<Track>()
                .Include(t => t.Signs)
                .FirstOrDefaultAsync(t => t.Id == trackId);

            if (track is null)
                throw new InfrastructureException("Track not found");

            return track;
        }

        public async Task<Track> GetTrackWithCategoryAsync(int trackId)
        {
            var track = await _dbContext.Set<Track>()
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == trackId);

            if (track is null)
                throw new InfrastructureException("Track not found");

            return track;
        }
    }
}


