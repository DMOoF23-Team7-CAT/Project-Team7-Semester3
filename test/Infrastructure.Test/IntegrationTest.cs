using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Repositories;
using Rally.Infrastructure.Repositories.Base;

namespace Infrastructure.Test
{
    public class IntegrationTest
    {
        [Fact]
        public async Task SignBaseRepository_GetAllAsync_ShouldReturnAllSignBases()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<RallyContext>()
                .UseSqlServer("Server=10.56.8.36;Database=DB_F23_23;User Id=DB_F23_USER_23;Password=OPENDB_23;TrustServerCertificate=True;") // Use real database
                .Options;

            using var context = new RallyContext(options);
            var repository = new SignBaseRepository(context);

            // Act  
            var signBases = await repository.GetAllAsync();

            // Assert
            using (new AssertionScope())
            {
                signBases.Should().NotBeNullOrEmpty();
                signBases.Should().BeOfType<List<SignBase>>();                
            }
            
            
        }
    }
}
