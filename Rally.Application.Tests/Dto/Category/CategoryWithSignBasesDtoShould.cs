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

    [Fact]
    public void HaveIdByDefault()
    {
        CategoryWithSignBasesDto sut = new CategoryWithSignBasesDto();

        Assert.NotNull(sut.Id);
    }


    // TDD - Denne test fejler nu, men bør ikke fejle hvis/når intup validering bliver lavet.
    [Fact]
    public void NotContainSpecialCharacters()
    {
        var sut = new CategoryWithSignBasesDto();

        var invalidName = "!/Bane?";

        var exception = Assert.Throws<ArgumentException>(() => sut.Name = invalidName);
        Assert.Contains("Name cannot contain '!' or '?' characters.", exception.Message);
    }
}

