using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Track> GetTrackWithSigns(int id)
        {
            var spec = new TrackWithSignsSpecification(id);
            var track = (await GetAsync(spec)).FirstOrDefault();

            if (track is null)
            {
                throw new KeyNotFoundException("Track not found");
            }
            return track;
        }

        public async Task<Track> GetTrackWithCategory(int id)
        {
            var spec = new TrackWithCategorySpecification(id);
            var track = (await GetAsync(spec)).FirstOrDefault();

            if (track is null)
            {
                throw new KeyNotFoundException("Track not found");
            }
            return track;
        }
    }
}


