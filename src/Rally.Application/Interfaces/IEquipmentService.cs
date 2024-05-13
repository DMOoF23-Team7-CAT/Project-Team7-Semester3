using Rally.Application.Dto.Equipment;

namespace Rally.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAll();
        Task<EquipmentDto> GetById(int id);
        Task<EquipmentDto> Create(EquipmentWithoutIdDto dto);
        Task Update(EquipmentWithoutIdDto dto, int id);
        Task Delete(int id);

        Task<EquipmentWithEquipmentBaseDto> GetEquipmentWithEquipmentBase(int equipmentId);
    }
}

