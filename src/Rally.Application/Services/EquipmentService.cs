using AspnetRun.Core.Repositories.Base;
using Rally.Application.Dto.Equipment;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentService : Service<EquipmentDto, Equipment, EquipmentWithoutIdDto>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IRepository<Equipment> repository, IEquipmentRepository equipmentRepository) : base(repository)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
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

