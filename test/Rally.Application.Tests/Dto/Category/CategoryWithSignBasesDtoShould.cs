namespace Rally.Application.Dto.Category;

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
}

