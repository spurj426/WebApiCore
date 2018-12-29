using System;
using Microsoft.Extensions.Options;
using WebApiCore.Common.Config;
using WebApiCore.Services.Strategy.Values;

namespace WebApiCore.Services.Factory
{
    public class ClientFactory : IClientFactory
    {
        private readonly IOptions<ValuesServiceConfig> _valuesServiceOptions;

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
                    // IMPORTANT:  The Clients are bootstrapped here -> notice the Json and Xml clients do not
                    // take a mapper of type json or xml directly:  The provider we are passing in does.
                    case ValuesServiceMapper.Xml:
                        return null; // return new ValuesClient(new FileSystemProvider(_valuesServiceOptions, new XmlMapper()));
                    default:
                        return null; // return new ValuesClient(new FileSystemProvider(_valuesServiceOptions, new JsonMapper()));
                }
            }
            throw new ArgumentException("Only the Values Service File System provider supported at this time");
        }
                
    }
}
