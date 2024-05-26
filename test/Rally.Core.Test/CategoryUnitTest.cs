using Rally.Core.Entities;

namespace Rally.Core.Test;

public class CategoryUnitTest
{
    [Fact]
    public void CategoryHasEmptyCollectionsWhenCreated()
    {
        Category category= new Category();

        Assert.Empty(category.Tracks);
        Assert.Empty(category.SignBases);
    }
}

