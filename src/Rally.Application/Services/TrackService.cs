using Rally.Core.Repositories.Base;
using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Application.Utilities;

namespace Rally.Application.Services
{
    public class TrackService : Service<TrackDto, Track, TrackWithoutIdDto>, ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUserContext _userContext;

        public TrackService(IRepository<Track> repository, ITrackRepository trackRepository, IUserContext userContext) : base(repository)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
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

        public async Task<TrackDto> CreateTrackWithUser(TrackDto trackDto)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null)
                throw new ApplicationException("Current user is null");

            var track = ObjectMapper.Mapper.Map<Track>(trackDto);
            if (track is null)
                throw new ApplicationException("Track could not be mapped");

            track.UserId = currentUser.Id;

            await _trackRepository.AddAsync(track);

            var newTrack = ObjectMapper.Mapper.Map<TrackDto>(track);
            if (newTrack is null)
                throw new ApplicationException("Track could not be mapped");

            return newTrack;
        }

        public async Task<TrackWithCategorySigns> LoadTrack(int trackId)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null)
                throw new ApplicationException("Current user is null");

            var track = await _trackRepository.LoadTrackAsync(trackId);

            if (track.UserId != currentUser.Id)
                throw new ApplicationException("Track does not belong to current user");

            var mappedTrack = ObjectMapper.Mapper.Map<TrackWithCategorySigns>(track);
            if (mappedTrack is null)
                throw new ApplicationException("Track could not be mapped");

            return mappedTrack;
        }
    }
}

