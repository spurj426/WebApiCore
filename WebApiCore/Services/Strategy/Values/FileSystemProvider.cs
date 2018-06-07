using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebApiCore.Services.Config;

namespace WebApiCore.Services.Strategy.Values
{
    public class FileSystemProvider : IValuesProvider
    {
        private readonly IOptions<ValuesServiceConfig> _options;
        private readonly IValuesMapper _valuesMapper;

        public FileSystemProvider(IOptions<ValuesServiceConfig> options, IValuesMapper mapper)
        {
            _options = options;
            _valuesMapper = mapper;
        }

        public IEnumerable<string> MakeRequest()
        {
            var file = LoadFile().Result;
            return _valuesMapper.MapResponse(file);
        }

        private async Task<object> LoadFile()
        {
            using (var sr = new StreamReader(_options.Value.FileSystemDataSource))
            {
                return await sr.ReadToEndAsync();
            }
        }
    }
}
