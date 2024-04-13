using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IAppLogger<EquipmentService> _logger;

        public EquipmentService(IEquipmentRepository equipmentRepository, IAppLogger<EquipmentService> logger)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // TODO: Implement the methods for the Equipment
    }
}

