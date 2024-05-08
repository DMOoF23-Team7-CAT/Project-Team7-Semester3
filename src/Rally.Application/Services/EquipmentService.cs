using Rally.Application.Dto.Equipment;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
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

        public Task<IEnumerable<EquipmentDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentDto> Create(EquipmentWithoutIdDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EquipmentDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<EquipmentWithEquipmentBaseDto> GetEquipmentWithEquipmentBase(int equipmentId)
        {
            var equipment = await _equipmentRepository.GetEquipmentWithEquipmentBaseAsync(equipmentId);

            var mappedEquipment = ObjectMapper.Mapper.Map<EquipmentWithEquipmentBaseDto>(equipment);
            if (mappedEquipment is null)
                throw new ApplicationException("Equipment with EquipmentBase could not be mapped.");

            return mappedEquipment;
        }
    }
}

