using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignBaseService :  ISignBaseService
    {
        private readonly ISignBaseRepository _SignBaseRepository;
        public SignBaseService(ISignBaseRepository SignBaseRepository)
        {
            _SignBaseRepository = SignBaseRepository ?? throw new ArgumentNullException(nameof(SignBaseRepository));
        }

        public Task<IEnumerable<SignBaseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SignBaseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SignBaseDto> Create(SignBaseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SignBaseDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<SignBaseDto> GetSignBaseWithCategory(int SignBaseId)
        {
            var SignBase = await _SignBaseRepository.GetSignBaseWithCategoryAsync(SignBaseId);

            var mappedSignBase = ObjectMapper.Mapper.Map<SignBaseDto>(SignBase);
            if (mappedSignBase is null)
                throw new ApplicationException("SignBase with Category could not be mapped");

            return mappedSignBase;
        }

        public async Task<SignBaseWithEquipmentBaseDto> GetSignBaseWithEquipmentBase(int SignBaseId)
        {
            var SignBase = await _SignBaseRepository.GetSignBaseWithEquipmentBaseAsync(SignBaseId);

            var mappedSignBase = ObjectMapper.Mapper.Map<SignBaseWithEquipmentBaseDto>(SignBase);
            if (mappedSignBase is null)
                throw new ApplicationException("SignBase with EquipmentBase could not be mapped");

            return mappedSignBase;
        }


    }
}

