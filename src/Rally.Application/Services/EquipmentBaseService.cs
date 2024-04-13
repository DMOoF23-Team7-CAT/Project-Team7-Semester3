using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentBaseService : IEquipmentBaseService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly IEquipmentBaseRepository _equipmentBaseRepository;
        private readonly IAppLogger<EquipmentBaseService> _logger;

        public EquipmentBaseService(IEquipmentBaseRepository equipmentBaseRepository, IAppLogger<EquipmentBaseService> logger)
        {
            _equipmentBaseRepository = equipmentBaseRepository ?? throw new ArgumentNullException(nameof(equipmentBaseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // TODO: Implement the methods for the EquipmentBase
    }

}

