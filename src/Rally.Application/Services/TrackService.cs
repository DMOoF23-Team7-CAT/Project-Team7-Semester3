using Rally.Core.Repositories.Base;
using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Application.Services.Account.AppUser;

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

        public async Task<Track> CreateTrackWithUser(TrackDto trackDto)
        {
            var currentUser = _userContext.GetCurrentUser();
            
            var track = ObjectMapper.Mapper.Map<Track>(trackDto);

            track.UserId = currentUser.Id;

            var newTrack = await _trackRepository.AddAsync(track);

            return newTrack;
        }
    }
}

