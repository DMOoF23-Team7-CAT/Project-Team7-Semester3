using FluentAssertions;
using Moq;
using Rally.Application.Dto.Category;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class CategoryServiceShould
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private readonly CategoryService _service;

        public CategoryServiceShould()
        {
            _mockRepo = new Mock<ICategoryRepository>();
            _service = new CategoryService(_mockRepo.Object);
        }

        [Fact]
        public async Task ReturnAllMappedCategories()
        {
            var sut = new List<Category> { new Category { Id = 1, Name = "Begynder" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sut);

            var result = await _service.GetAll();

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<CategoryDto>>();
        }

        [Fact]
        public async Task DeleteCategoryWhenExists()
        {
            var sut = new Category { Id = 1, Name = "Øvet" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(sut);
            _mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

            Func<Task> act = async () => await _service.Delete(1);

            await act.Should().NotThrowAsync();
        }
    }
}
