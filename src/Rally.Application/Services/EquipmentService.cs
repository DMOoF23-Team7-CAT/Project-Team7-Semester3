using FluentValidation;
using Rally.Application.Dto.Equipment;
using Rally.Application.Exceptions;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Validators;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
        }

        public async Task<IEnumerable<EquipmentDto>> GetAll()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            if (equipments is null)
                throw new NotFoundException("Equipment could not be found.");

            var mappedEquipments = ObjectMapper.Mapper.Map<IEnumerable<EquipmentDto>>(equipments);
            if (mappedEquipments is null)
                throw new MappingException("Equipment could not be mapped.");

            return mappedEquipments;
        }

        public async Task<EquipmentDto> GetById(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment is null)
                throw new NotFoundException("Equipment could not be found.");

            var mappedEquipment = ObjectMapper.Mapper.Map<EquipmentDto>(equipment);
            if (mappedEquipment is null)
                throw new MappingException("Equipment could not be mapped.");

            return mappedEquipment;
        }

        public async Task<EquipmentDto> Create(EquipmentWithoutIdDto dto)
        {
            var equipment = ObjectMapper.Mapper.Map<Equipment>(dto);
            if (equipment is null)
                throw new MappingException("Equipment could not be mapped.");

            var validator = new EquipmentValidator();
            var validationResult = await validator.ValidateAsync(equipment);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _equipmentRepository.AddAsync(equipment);

            return ObjectMapper.Mapper.Map<EquipmentDto>(equipment);
        }

        public async Task Delete(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment is null)
                throw new NotFoundException("Equipment could not be found.");

            await _equipmentRepository.DeleteAsync(equipment);
        }

        public async Task Update(EquipmentDto dto)
        {
            var oldEquipment = await _equipmentRepository.GetByIdAsync(dto.Id);
            if (oldEquipment is null)
                throw new NotFoundException("Equipment could not be found.");

            var equipment = ObjectMapper.Mapper.Map<Equipment>(dto);
            if (equipment is null)
                throw new MappingException("Equipment could not be mapped.");

            var validator = new EquipmentValidator();
            var validationResult = await validator.ValidateAsync(equipment);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _equipmentRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldEquipment));
        }

        public async Task<EquipmentWithEquipmentBaseDto> GetEquipmentWithEquipmentBase(int equipmentId)
        {
            var equipment = await _equipmentRepository.GetEquipmentWithEquipmentBaseAsync(equipmentId);

            var mappedEquipment = ObjectMapper.Mapper.Map<EquipmentWithEquipmentBaseDto>(equipment);
            if (mappedEquipment is null)
                throw new NotFoundException("Equipment with EquipmentBase could not be mapped.");

            return mappedEquipment;
        }
    }
}

