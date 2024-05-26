
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class CategoryValidatorTest
    {
        [Fact]
        public void IdIsRequired()
        {
            var category = new Category();
            var validator = new CategoryValidator();
            
            var result = validator.Validate(category);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(Category.Id));
        }

        [Fact]
        public void IdMustBeGraterThenZero()
        {
            var category = new Category() { Id = -1 };
            var validator = new CategoryValidator();
            
            var result = validator.Validate(category);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(Category.Id));
        }

        [Fact]
        public void NameIsRequired()
        {
            var category = new Category();
            var validator = new CategoryValidator();
            
            var result = validator.Validate(category);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(Category.Name));
        }
    }
}