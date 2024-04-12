using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class SignWithTrackSpecification : BaseSpecification<Sign>
    {
        public SignWithTrackSpecification(int signId) : base(s => s.Id == signId)
        {
            AddInclude(s => s.Track!);
        }
    }
}

