using Rally.Application.Dto.Sign;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ISignService : IService<SignDto, Sign>
    {
        //Task<SignWithTrackDto> GetSignWithTrack(int signId);
        Task<SignWithSignBaseDto> GetSignWithSignBases(int signId);
    }
}

