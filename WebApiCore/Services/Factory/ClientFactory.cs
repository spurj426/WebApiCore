using System;
using Microsoft.Extensions.Options;
using WebApiCore.Services.Config;
using WebApiCore.Services.Strategy.Values;

namespace WebApiCore.Services.Factory
{
    public class ClientFactory : IClientFactory
    {
        private readonly IOptions<ValuesServiceConfig> _valuesServiceOptions = null;

        public ClientFactory(IOptions<ValuesServiceConfig> valuesServiceOptions)
        {
            _valuesServiceOptions = valuesServiceOptions;
        }

        public IValuesClient GetValuesClient()
        {
            if (_valuesServiceOptions.Value.Provider == ValuesServiceProvider.FileSystem)
            {
                // For the POC filesystem implementation, the only unique properties of the client
                // are the file location and appropriate mapper.  In a real world situation, like
                // a payment gateway, there would be other properties to be configured in the client
                // like https Url, success and error code mapper / translators, logging, etc.
                switch (_valuesServiceOptions.Value.Mapper)
                {
                    case ValuesServiceMapper.Xml:
                        return new XmlClient(new FileSystemProvider(_valuesServiceOptions, new XmlMapper()));
                    default:
                        return new JsonClient(new FileSystemProvider(_valuesServiceOptions, new JsonMapper()));
                }
            }
            else
            {
                throw new ArgumentException("Only the Values Service File System provider supported at this time");
            }
        }
                
    }
}
