
using Rally.Core.Entities;

namespace Rally.Core.Test
{
    public class SignUnitTest
    {
        [Fact]
        public void SignHasEmptyStringsWhenCreated()
        {
            Sign sign= new Sign();

            Assert.Empty(sign.XCoordinate);
            Assert.Empty(sign.YCoordinate);
            Assert.Empty(sign.Rotation);
        }
    }
}

