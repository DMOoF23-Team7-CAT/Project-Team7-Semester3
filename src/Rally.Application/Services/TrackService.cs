using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class TrackService : ITrackService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly ITrackRepository _trackRepository;
        private readonly IAppLogger<TrackService> _logger;

        public TrackService(ITrackRepository trackRepository, IAppLogger<TrackService> logger)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // TODO: Implement the methods for the Track
    }
}

