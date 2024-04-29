using Rally.Application.Dto.Category;

namespace Rally.Application;

public class CategoryWithSignBasesDtoShould
{
    [Fact]
    public void HaveNameInCorrectFormat()
    {
        CategoryWithSignBasesDto sut = new CategoryWithSignBasesDto();

        sut.Name = "Begynder bane";

        Assert.Matches("^[A-Za-zæøåÆØÅ ]+$", sut.Name);
    }

    [Fact]
    public void NotHaveNameByDefault()
    {
        CategoryWithSignBasesDto sut = new CategoryWithSignBasesDto();

        Assert.Empty(sut.Name);
    }

    [Fact]
    public void NotHaveRulesByDefault()
    {
        CategoryWithSignBasesDto sut = new CategoryWithSignBasesDto();

        Assert.Empty(sut.Rules);
    }

    [Fact]
    public void HaveIdByDefault()
    {
        CategoryWithSignBasesDto sut = new CategoryWithSignBasesDto();

        Assert.NotNull(sut.Id);
    }
}
