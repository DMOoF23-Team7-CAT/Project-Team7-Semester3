using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignService : ISignService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly ISignRepository _signRepository;

        public SignService(ISignRepository signRepository)
        {
            _signRepository = signRepository ?? throw new ArgumentNullException(nameof(signRepository));
        }
        // TODO: Implement the methods for the Sign
    }
}

