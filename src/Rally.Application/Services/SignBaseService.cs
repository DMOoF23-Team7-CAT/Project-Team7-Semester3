using FluentValidation;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.SignBase;
using Rally.Application.Exceptions;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Validators;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignBaseService :  ISignBaseService
    {
        private readonly ISignBaseRepository _signBaseRepository;
        public SignBaseService(ISignBaseRepository SignBaseRepository)
        {
            _signBaseRepository = SignBaseRepository ?? throw new ArgumentNullException(nameof(SignBaseRepository));
        }

        public async Task<IEnumerable<SignBaseDto>> GetAll()
        {
            var signBases = await _signBaseRepository.GetAllAsync();
            if (signBases is null)
                throw new NotFoundException("SignBases could not be found.");

            var mappedSignBases = ObjectMapper.Mapper.Map<IEnumerable<SignBaseDto>>(signBases);
            if (mappedSignBases is null)
                throw new MappingException("SignBases could not be mapped.");

            return mappedSignBases;
        }

        public async Task<SignBaseDto> GetById(int id)
        {
            var signBase = await _signBaseRepository.GetByIdAsync(id);
            if (signBase is null)
                throw new NotFoundException("SignBase could not be found.");

            var mappedSignBase = ObjectMapper.Mapper.Map<SignBaseDto>(signBase);
            if (mappedSignBase is null)
                throw new MappingException("SignBase could not be mapped.");

            return mappedSignBase;
        }

        public async Task<SignBaseDto> Create(SignBaseDto dto)
        {
            await ValidateIfExist(dto);

            var signBase = ObjectMapper.Mapper.Map<SignBase>(dto);
            if (signBase is null)
                throw new MappingException("SignBase could not be mapped.");

            var validator = new SignBaseValidator();
            var validationResult = await validator.ValidateAsync(signBase);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _signBaseRepository.AddAsync(signBase);
            
            return ObjectMapper.Mapper.Map<SignBaseDto>(signBase);
        }

        public async Task Delete(int id)
        {
            var signBase = await _signBaseRepository.GetByIdAsync(id);

            if (signBase is null)
                throw new NotFoundException("SignBase could not be found.");

            await _signBaseRepository.DeleteAsync(signBase);
        }

        public async Task Update(SignBaseDto dto)
        {
            var oldSignBase = await _signBaseRepository.GetByIdAsync(dto.Id);
            if (oldSignBase is null)
                throw new NotFoundException("SignBase could not be found.");

            var signBase = ObjectMapper.Mapper.Map<SignBase>(dto);
            if (signBase is null)
                throw new MappingException("SignBase could not be mapped.");

            var validator = new SignBaseValidator();
            var validationResult = await validator.ValidateAsync(signBase);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                await _signBaseRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldSignBase));
            }
            catch (Exception e)
            {
                throw new DatabaseException("An error ocurred while updating", e);
            }
        }

        public async Task<SignBaseDto> GetSignBaseWithCategory(int SignBaseId)
        {
            var SignBase = await _signBaseRepository.GetSignBaseWithCategoryAsync(SignBaseId);

            var mappedSignBase = ObjectMapper.Mapper.Map<SignBaseDto>(SignBase);
            if (mappedSignBase is null)
                throw new MappingException("SignBase with Category could not be mapped");

            return mappedSignBase;
        }

        public async Task<SignBaseWithEquipmentBaseDto> GetSignBaseWithEquipmentBase(int SignBaseId)
        {
            var SignBase = await _signBaseRepository.GetSignBaseWithEquipmentBaseAsync(SignBaseId);

            var mappedSignBase = ObjectMapper.Mapper.Map<SignBaseWithEquipmentBaseDto>(SignBase);
            if (mappedSignBase is null)
                throw new MappingException("SignBase with EquipmentBase could not be mapped");

            return mappedSignBase;
        }

        private async Task ValidateIfExist(SignBaseDto dto)
        {
            if (dto.Id != 0)
            {
                var existingEntity = await _signBaseRepository.GetByIdAsync(dto.Id);
                if (existingEntity != null)
                    throw new NotFoundException($"SignBase with ID {dto.Id} already exists");
            }
        }


    }
}

