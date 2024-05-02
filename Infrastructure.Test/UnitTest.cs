using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Repositories;
using Rally.Infrastructure.Repositories.Base;

namespace Infrastructure.Test
{
    public class UnitTest
    {
        [Fact]
        public async Task CategoryRepository_GetAllAsync_ShouldReturnAllCategories()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<RallyContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Use in-memory database
                .Options;

            using var context = new RallyContext(options);

            context.Categories.Add(new Category { Id = 1, Name = "Category1" });
            context.Categories.Add(new Category { Id = 2, Name = "Category2" });
            context.Categories.Add(new Category { Id = 3, Name = "Category3" });
            await context.SaveChangesAsync();

            var repository = new Repository<Category>(context);

            // Act
            var categories = await repository.GetAllAsync();

            // Assert            
            categories.Should().NotBeNullOrEmpty();
            categories.Should().HaveCount(3);
            categories.First().Name.Should().Be("Category1");
        }
    }
}