using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Application.Validators;
using FluentValidation;
using Rally.Application.Exceptions;

namespace Rally.Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUserContext _userContext;

        public TrackService(ITrackRepository trackRepository, IUserContext userContext)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<TrackWithCategoryDto> GetTrackWithCategory(int trackId)
        {
            var track = await _trackRepository.GetTrackWithCategoryAsync(trackId);

            var mappedTrack = ObjectMapper.Mapper.Map<TrackWithCategoryDto>(track);
            if (mappedTrack is null)
                throw new MappingException("Track with category could not be mapped");

            return mappedTrack;
        }

        public async Task<LoadTrackDto> LoadTrack(int trackId)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null)
                throw new UnauthorizedAccessException("Current user is null");

            var track = await _trackRepository.LoadTrackAsync(trackId);

            if (track.UserId != currentUser.Id)
                throw new UnauthorizedAccessException("Track does not belong to current user");

            var mappedTrack = ObjectMapper.Mapper.Map<LoadTrackDto>(track);
            if (mappedTrack is null)
                throw new MappingException("Track could not be mapped");

            return mappedTrack;
        }

        public async Task<IEnumerable<TrackDto>> GetAll()
        {
            var tracks = await _trackRepository.GetAllAsync();
            if (tracks is null)
                throw new NotFoundException("Tracks could not be found.");

            var mappedTracks = ObjectMapper.Mapper.Map<IEnumerable<TrackDto>>(tracks);
            if (mappedTracks is null)
                throw new MappingException("Tracks could not be mapped.");

            return mappedTracks;
        }

        public async Task<TrackDto> GetById(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            if (track is null)
                throw new NotFoundException("Track could not be found.");

            var mappedTrack = ObjectMapper.Mapper.Map<TrackDto>(track);
            if (mappedTrack is null)
                throw new MappingException("Track could not be mapped.");

            return mappedTrack;
        }

        public async Task<TrackDto> Create(TrackWithOutIdDto dto)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null)
                throw new InvalidOperationException("Current user is not available.");

            var track = ObjectMapper.Mapper.Map<Track>(dto);
            if (track is null)
                throw new MappingException("Track could not be mapped from the provided data.");

            var validator = new TrackValidator();
            var validationResult = await validator.ValidateAsync(track);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);

            track.UserId = currentUser.Id;

            await _trackRepository.AddAsync(track);

            var newTrack = ObjectMapper.Mapper.Map<TrackDto>(track);
            if (newTrack is null)
                throw new MappingException("Newly created track could not be mapped to TrackDto.");

            return newTrack;
        }

        public async Task Update(TrackWithOutIdDto dto, int trackId)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null)
                throw new NotFoundException("Current user is not available.");

            var oldTrack = await _trackRepository.GetByIdAsync(trackId);
            if (oldTrack is null)
                throw new NotFoundException($"Track with ID {trackId} could not be found.");

            if (oldTrack.UserId != currentUser.Id)
                throw new UnauthorizedAccessException($"User is not authorized to alter track with ID {oldTrack.Id}.");

            var track = ObjectMapper.Mapper.Map<Track>(dto);
            if (track is null)
                throw new MappingException("Track could not be mapped from the provided data.");

            var validator = new TrackValidator();
            var validationResult = await validator.ValidateAsync(track);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);

            await _trackRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldTrack));
        }

        public async Task Delete(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            if (track is null)
                throw new NotFoundException($"Track with ID {id} could not be found.");

            await _trackRepository.DeleteAsync(track);
        }
    }
}

