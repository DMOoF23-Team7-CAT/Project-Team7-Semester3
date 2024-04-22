using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ISignBaseService : IService<SignBaseDto, SignBase>
    {
        Task<SignBaseDto> GetSignBaseWithEquipmentBase(int SignBaseId);
        Task<SignBaseDto> GetSignBaseWithCategory(int SignBaseId);
    }
}

