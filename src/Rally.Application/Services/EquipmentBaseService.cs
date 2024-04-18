using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using Rally.Application.Dto;
using Rally.Application.Interfaces;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentBaseService : Service<EquipmentBaseDto, EquipmentBase>, IEquipmentBaseService
    {
        public EquipmentBaseService(IRepository<EquipmentBase> repository) : base(repository)
        {
        }
    }

}

