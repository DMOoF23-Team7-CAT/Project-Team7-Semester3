using Rally.Application.Dto.Sign;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ISignService : IService<SignDto, Sign, SignWithoutIdDto>
    {
        Task<SignWithSignBaseDto> GetSignWithSignBases(int signId);
        Task<SignWithSignBaseDto> CreateSignWithSignBase(SignWithSignBaseDto signDto, int signBaseId);
    }
}

