using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class EquipmentWithEquipmentBaseSpecification : BaseSpecification<Equipment>
    {
        public EquipmentWithEquipmentBaseSpecification(int equipmentId) : base(e => e.Id == equipmentId)
        {
            AddInclude(e => e.EquipmentBase!);
        }
    }
}