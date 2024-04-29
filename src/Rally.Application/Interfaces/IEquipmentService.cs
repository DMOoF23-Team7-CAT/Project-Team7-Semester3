using Rally.Application.Dto.Equipment;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface IEquipmentService : IService<EquipmentDto, Equipment, EquipmentWithoutIdDto>
    {
        Task<EquipmentWithEquipmentBaseDto> GetEquipmentWithEquipmentBase(int equipmentId);
    }
}

