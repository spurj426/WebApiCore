using Microsoft.Extensions.Options;
using Moq;
using WebApiCore.Common.Config;
using Xunit;

namespace WebApiCore.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void ValuesService_Config_Is_Correct()
        {
            var jsonValueServiceConfig = new ValuesServiceConfig
            {
                Mapper = ValuesServiceMapper.Json,
                Provider = ValuesServiceProvider.FileSystem,
                DataSource = @"C:\Workspace\WebApiCore\WebApiCore\MockData\Values.json"
            };

            var mockConfig = new Mock<IOptions<ValuesServiceConfig>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            mockConfig.Setup(x => x.Value).Returns(jsonValueServiceConfig);

            Assert.IsType<ValuesServiceMapper>(mockConfig.Object.Value.Mapper);
            Assert.Equal(ValuesServiceProvider.FileSystem.ToString(), mockConfig.Object.Value.Provider.ToString());
            Assert.Equal(@"C:\Workspace\WebApiCore\WebApiCore\MockData\Values.json", mockConfig.Object.Value.DataSource);
        }

    }
}
