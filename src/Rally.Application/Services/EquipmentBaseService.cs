using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Interfaces;
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

        public Task<IEnumerable<EquipmentBaseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentBaseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentBaseDto> Create(EquipmentBaseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EquipmentBaseDto dto)
        {
            throw new NotImplementedException();
        }
    }

}

