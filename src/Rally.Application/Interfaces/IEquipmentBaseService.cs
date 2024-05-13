using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Interfaces
{
    public interface IEquipmentBaseService
    {
        Task<IEnumerable<EquipmentBaseDto>> GetAll();
        Task<EquipmentBaseDto> GetById(int id);
        Task<EquipmentBaseDto> Create(EquipmentBaseDto dto);
        Task Update(EquipmentBaseDto dto, int id);
        Task Delete(int id);

    }
}

