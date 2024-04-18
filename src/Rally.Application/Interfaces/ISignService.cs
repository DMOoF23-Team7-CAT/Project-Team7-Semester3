using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ISignService : IService<SignDto, Sign>
    {
        Task<SignDto> GetSignWithTrack(int signId);
        Task<SignDto> GetSignWithExercises(int signId);
    }
}

