using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebApiCore.Services.Config;

namespace WebApiCore.Services.Strategy.Values
{
    /// <summary>
    /// Provides the actual implementation for making requests from the client.
    /// </summary>
    public class FileSystemProvider : IValuesProvider
    {
        private readonly IOptions<ValuesServiceConfig> _options;
        private readonly IValuesMapper _valuesMapper;

        public FileSystemProvider(IOptions<ValuesServiceConfig> options, IValuesMapper mapper)
        {
            _options = options;
            _valuesMapper = mapper;
        }

        public async Task<IEnumerable<string>> FetchData()
        {
            var file = await LoadFile();
            return _valuesMapper.MapResponse(file);
        }

        private async Task<object> LoadFile()
        {
            try
            {
                using (var sr = new StreamReader(_options.Value.FileSystemDataSource))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (ArgumentException aex)
            {
                throw new ArgumentException(aex.Message);
            }
            catch (FileNotFoundException fex)
            {
                throw new FileNotFoundException(fex.Message);
            }
            
        }
    }
}
