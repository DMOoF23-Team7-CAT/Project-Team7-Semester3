using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class SignBaseWithCategorySpecification : BaseSpecification<SignBase>
    {
        public SignBaseWithCategorySpecification(int SignBaseId) : base(e => e.Id == SignBaseId)
        {
            AddInclude(e => e.Category!);
        }
    }
}