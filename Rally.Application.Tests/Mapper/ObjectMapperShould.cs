using Rally.Application.Dto.Category;
using Rally.Core.Entities;

namespace Rally.Application.Mapper
{
    public class ObjectMapperShould
    {
        [Fact]
        public void BeSingleton()
        {
            var mapper1 = ObjectMapper.Mapper;
            var mapper2 = ObjectMapper.Mapper;
            Assert.Same(mapper1, mapper2);
        }

        [Fact]
        public void HaveValidConfiguration()
        {
            var mapper = ObjectMapper.Mapper;
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void MapFromSourceToDestination()
        {
            var mapper = ObjectMapper.Mapper;
            var source = new Category();
            var destination = mapper.Map<CategoryDto>(source); 

            Assert.NotNull(destination);
        }
    }
}
