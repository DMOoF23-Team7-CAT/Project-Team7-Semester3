using Rally.Application.Dto.Sign;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignService : ISignService
    {
        private readonly ISignRepository _signRepository;
        public SignService(ISignRepository signRepository)
        {
            _signRepository = signRepository ?? throw new ArgumentNullException(nameof(signRepository));
        }

        public Task<IEnumerable<SignDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SignDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SignDto> Create(SignWithoutIdDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SignDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<SignWithSignBaseDto> GetSignWithSignBases(int signId)
        {
            var sign = await _signRepository.GetSignWithSignBasesAsync(signId);

            var mappedSign = ObjectMapper.Mapper.Map<SignWithSignBaseDto>(sign);
            if (mappedSign is null)
                throw new ApplicationException("Sign with SignBases could not be mapped");

            return mappedSign;
        }

    }
}

