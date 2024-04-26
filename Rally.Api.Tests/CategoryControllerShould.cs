using Microsoft.AspNetCore.Mvc;
using Moq;
using Rally.Api.Controllers;
using Rally.Application.Dto;
using Rally.Application.Interfaces;

namespace Rally.Api;

public class CategoryControllerShould
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    private readonly CategoryController _controller;

    public CategoryControllerShould()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _controller = new CategoryController(_mockCategoryService.Object);
    }

    [Fact]
    public async Task GetCategoryWithSignBases_ReturnOKResult_WhenCategoryExists()
    {
        // Arrange
        int testCategoryId = 1;
        var categoryDto = new CategoryDto { Id = 1, Name = "TestName", Rules = "TestRule" };
        _mockCategoryService.Setup(service => service.GetCategoryWithSignBases(testCategoryId))
            .ReturnsAsync(categoryDto);

        // Act
        var result = await _controller.GetCategoriesWithSignBases(testCategoryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CategoryDto>(okResult.Value);
        Assert.Equal(categoryDto, returnValue);
    }
}
