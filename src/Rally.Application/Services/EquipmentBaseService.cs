using FluentValidation;
using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Exceptions;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Validators;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentBaseService : IEquipmentBaseService
    {
        private readonly IEquipmentBaseRepository _equipmentBaseRepository;
        public EquipmentBaseService(IEquipmentBaseRepository equipmentBaseRepository)
        {
            _equipmentBaseRepository = equipmentBaseRepository ?? throw new ArgumentNullException(nameof(equipmentBaseRepository));
        }

        public async Task<IEnumerable<EquipmentBaseDto>> GetAll()
        {
            var equipmentBases = await _equipmentBaseRepository.GetAllAsync();
            if (equipmentBases is null)
                throw new NotFoundException("EquipmentBases could not be found.");

            var mappedEquipmentBases = ObjectMapper.Mapper.Map<IEnumerable<EquipmentBaseDto>>(equipmentBases);
            if (mappedEquipmentBases is null)
                throw new MappingException("EquipmentBases could not be mapped.");

            return mappedEquipmentBases;
        }

        public async Task<EquipmentBaseDto> GetById(int id)
        {
            var equipmentBase = await _equipmentBaseRepository.GetByIdAsync(id);
            if (equipmentBase is null)
                throw new NotFoundException("EquipmentBase could not be found.");

            var mappedEquipmentBase = ObjectMapper.Mapper.Map<EquipmentBaseDto>(equipmentBase);
            if (mappedEquipmentBase is null)
                throw new MappingException("EquipmentBase could not be mapped.");

            return mappedEquipmentBase;
        }

        public async Task<EquipmentBaseDto> Create(EquipmentBaseDto dto)
        {
            await ValidateIfExist(dto);

            var equipmentBase = ObjectMapper.Mapper.Map<EquipmentBase>(dto);
            if (equipmentBase is null)
                throw new MappingException("EquipmentBase could not be mapped.");

            var validator = new EquipmentBaseValidator();
            var validationResult = await validator.ValidateAsync(equipmentBase);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _equipmentBaseRepository.AddAsync(equipmentBase);

            return ObjectMapper.Mapper.Map<EquipmentBaseDto>(equipmentBase);
        }

        public async Task Delete(int id)
        {
            var equipmentBase = await _equipmentBaseRepository.GetByIdAsync(id);
            if (equipmentBase is null)
                throw new NotFoundException("EquipmentBase could not be found.");

            await _equipmentBaseRepository.DeleteAsync(equipmentBase);
        }

        public async Task Update(EquipmentBaseDto dto)
        {
            var oldEquipmentBase = await _equipmentBaseRepository.GetByIdAsync(dto.Id);
            if (oldEquipmentBase is null)
                throw new NotFoundException("EquipmentBase could not be found.");

            var equipmentBase = ObjectMapper.Mapper.Map<EquipmentBase>(dto);
            if (equipmentBase is null)
                throw new MappingException("EquipmentBase could not be mapped.");

            var validator = new EquipmentBaseValidator();
            var validationResult = await validator.ValidateAsync(equipmentBase);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _equipmentBaseRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldEquipmentBase));
        }

        private async Task ValidateIfExist(EquipmentBaseDto dto)
        {
            if (dto.Id != 0)
            {
                var existingEntity = await _equipmentBaseRepository.GetByIdAsync(dto.Id);
                if (existingEntity != null)
                    throw new NotFoundException($"EquipmentBase with ID {dto.Id} already exists");
            }
        }
    }

}

