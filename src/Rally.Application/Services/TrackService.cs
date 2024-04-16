using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class TrackService : ITrackService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
        }
        // TODO: Implement the methods for the Track
    }
}

