using Rally.Application.Dto.Sign;

namespace Rally.Application.Interfaces
{
    public interface ISignService
    {
        Task<IEnumerable<SignDto>> GetAll();
        Task<SignDto> GetById(int id);
        Task<SignDto> Create(SignWithoutIdDto dto);
        Task Update(SignWithoutIdDto dto, int id);
        Task Delete(int id);
        Task<SignWithSignBaseDto> GetSignWithSignBases(int signId);
    }
}

