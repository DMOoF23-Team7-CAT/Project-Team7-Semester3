using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class TrackWithCategorySpecification : BaseSpecification<Track>
    {
        public TrackWithCategorySpecification(int trackId) : base(t => t.Id == trackId)
        {
            AddInclude(t => t.Category!);
        }
    }
}

