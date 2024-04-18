using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces.Base;
using Rally.Application.Services.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface IEquipmentService : IService<EquipmentDto, Equipment>
    {
        Task<EquipmentDto> GetEquipmentWithEquipmentBase(int equipmentId);
    }
}

