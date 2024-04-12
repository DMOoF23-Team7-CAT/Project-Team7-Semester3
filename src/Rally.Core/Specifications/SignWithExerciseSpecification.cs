using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class SignWithExerciseSpecification : BaseSpecification<Sign>
    {
        public SignWithExerciseSpecification(int signId) : base(s => s.Id == signId)
        {
            AddInclude(s => s.Exercise!);
        }
    }
}