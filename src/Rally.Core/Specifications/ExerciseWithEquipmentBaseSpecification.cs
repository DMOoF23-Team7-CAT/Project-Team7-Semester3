using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class ExerciseWithEquipmentBaseSpecification : BaseSpecification<Exercise>
    {
        public ExerciseWithEquipmentBaseSpecification(int exerciseId) : base(e => e.Id == exerciseId)
        {
            AddInclude(e => e.EquipmentBase!);
        }
    }
}