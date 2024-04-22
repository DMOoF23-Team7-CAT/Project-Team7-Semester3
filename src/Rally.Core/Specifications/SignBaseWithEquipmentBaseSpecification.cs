using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class SignBaseWithEquipmentBaseSpecification : BaseSpecification<SignBase>
    {
        public SignBaseWithEquipmentBaseSpecification(int SignBaseId) : base(e => e.Id == SignBaseId)
        {
            AddInclude(e => e.EquipmentBase!);
        }
    }
}