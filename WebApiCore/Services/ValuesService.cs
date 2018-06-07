using System.Collections.Generic;
using WebApiCore.Interfaces;
using WebApiCore.Services.Factory;
using WebApiCore.Services.Strategy.Values;

namespace WebApiCore.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IClientFactory _clientFactory = null;
        private IValuesClient _valuesClient = null;

        public ValuesService(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IEnumerable<string> GetValues()
        {
            // We have two options.
            // (1) Wireup the Values Client via IoC with a specific implementation
            // (2) Use a factory method based on configuration (below)
            // (3) It would also be possible to select implementation at runtime,
            //     but this example assumes an implementation selected based on config.
            _valuesClient = _clientFactory.GetValuesClient();
            return _valuesClient.MakeRequest();
        }
    }
}
