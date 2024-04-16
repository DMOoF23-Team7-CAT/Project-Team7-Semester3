using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentBaseService : IEquipmentBaseService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly IEquipmentBaseRepository _equipmentBaseRepository;

        public EquipmentBaseService(IEquipmentBaseRepository equipmentBaseRepository)
        {
            _equipmentBaseRepository = equipmentBaseRepository ?? throw new ArgumentNullException(nameof(equipmentBaseRepository));
        }
        // TODO: Implement the methods for the EquipmentBase
    }

}

