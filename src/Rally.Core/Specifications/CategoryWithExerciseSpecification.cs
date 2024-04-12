using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Specifications.Base;

namespace Rally.Core.Specifications
{
    public class CategoryWithExerciseSpecification : BaseSpecification<Category>
    {
        public CategoryWithExerciseSpecification(int categoryId) : base(c => c.Id == categoryId)
        {
            AddInclude(c => c.Exercises);
        }
    }
}