using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface IEquipmentBaseService : IService<EquipmentBaseDto, EquipmentBase, EquipmentBaseWithoutIdDto>
    {
    }
}

