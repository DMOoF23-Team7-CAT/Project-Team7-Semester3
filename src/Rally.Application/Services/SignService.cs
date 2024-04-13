using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignService : ISignService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly ISignRepository _signRepository;
        private readonly IAppLogger<SignService> _logger;

        public SignService(ISignRepository signRepository, IAppLogger<SignService> logger)
        {
            _signRepository = signRepository ?? throw new ArgumentNullException(nameof(signRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // TODO: Implement the methods for the Sign
    }
}

