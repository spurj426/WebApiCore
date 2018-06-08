using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using Moq;
using WebApiCore.Services.Config;
using WebApiCore.Services.Strategy.Values;
using Xunit;

namespace WebApiCore.Tests
{
    public class MapperTests
    {
        #region JsonMapper

        [Theory]
        [ClassData(typeof(JsonMapperData))]
        public void JsonMapper_Loads_Json_SimpleObject_SimpleProperties_Correctly(string jsonInput, IEnumerable<string> expectedResult)
        {
            IValuesMapper valuesMapper = new JsonMapper();
            IEnumerable<string> finalResult = valuesMapper.MapResponse(jsonInput);
            Assert.Equal(expectedResult, finalResult);
        }

        #region JsonMapper Setup
        public class JsonMapperData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { JsonSimpleObject, JsonEnumerableStringResult };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        private static readonly string JsonSimpleObject = "{\r\n \"Value1\": \"Value 1 from json format\",\r\n  \"Value2\": \"Value 2 from json format\"\r\n}";
        private static readonly List<string> JsonEnumerableStringResult = new List<string> { "Value 1 from json format", "Value 2 from json format" };
        #endregion

        #endregion

        #region XmlMapper

        [Theory]
        [ClassData(typeof(XmlMapperData))]
        public void Xmlapper_Loads_Xml_SimpleDom_Using_desc_Attribute_Correctly(string xmlInput, IEnumerable<string> expectedResult)
        {
            IValuesMapper valuesMapper = new XmlMapper();
            IEnumerable<string> finalResult = valuesMapper.MapResponse(xmlInput);
            Assert.Equal(expectedResult, finalResult);
        }

        #region XmlMapperSetup
        public class XmlMapperData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { XmlSimpleDomUsingDescAttribute, XmlEnumerableStringResult };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private static readonly string XmlSimpleDomUsingDescAttribute = @"<Values><value id = ""1"" desc=""Value 1 from xml format"" /><value id = ""2"" desc=""Value 2 from xml format"" /></Values>";
        private static readonly List<string> XmlEnumerableStringResult = new List<string> { "Value 1 from xml format", "Value 2 from xml format" };
        #endregion

        #endregion

        #region FileSystemProvider

        [Fact]
        public async void FileSystemProvider_MissingFilePath_ThrowsFileNotFoundException()
        {
            var jsonValueServiceConfig = new ValuesServiceConfig
            {
                Mapper = ValuesServiceMapper.Json,
                Provider = ValuesServiceProvider.FileSystem,
                FileSystemDataSource = string.Empty
            };

            var jsonMock = new Mock<IOptions<ValuesServiceConfig>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            jsonMock.Setup(ap => ap.Value).Returns(jsonValueServiceConfig);

            var jsonFileSystemProvider = new FileSystemProvider(jsonMock.Object, new JsonMapper());

            await Assert.ThrowsAsync<ArgumentException>(() => jsonFileSystemProvider.FetchData());
        }

        #endregion
    }
}
