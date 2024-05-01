using AspnetRun.Core.Repositories.Base;
using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class TrackService : Service<TrackDto, Track, TrackWithoutIdDto>, ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        public TrackService(IRepository<Track> repository, ITrackRepository trackRepository) : base(repository)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
        }

        public async Task<TrackWithSignsDto> GetTrackWithSigns(int trackId)
        {
            var track = await _trackRepository.GetTrackWithSignsAsync(trackId);

            var mappedTrack = ObjectMapper.Mapper.Map<TrackWithSignsDto>(track);
            if (mappedTrack is null)
                throw new ApplicationException("Track with signs could not be mapped");

            return mappedTrack;
        }

        public async Task<TrackWithCategoryDto> GetTrackWithCategory(int trackId)
        {
            var track = await _trackRepository.GetTrackWithCategoryAsync(trackId);

            var mappedTrack = ObjectMapper.Mapper.Map<TrackWithCategoryDto>(track);
            if (mappedTrack is null)
                throw new ApplicationException("Track with category could not be mapped");

            return mappedTrack;
        }
    }
}

