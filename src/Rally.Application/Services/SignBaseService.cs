using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Repositories.Base;
using AutoMapper.Internal.Mappers;
using Rally.Application.Dto;
using Rally.Application.Dto.Sign;
using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignBaseService : Service<SignBaseDto, SignBase, SignBaseWithoutIdDto>, ISignBaseService
    {
        private readonly ISignBaseRepository _SignBaseRepository;
        public SignBaseService(IRepository<SignBase> repository, ISignBaseRepository SignBaseRepository) : base(repository)
        {
            _SignBaseRepository = SignBaseRepository ?? throw new ArgumentNullException(nameof(SignBaseRepository));
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

