using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Services.Providers.Values;

namespace WebApiCore.Services.Strategy.Values
{
    public class ValuesClient : IValuesClient
    {
        private readonly IValuesProvider _valuesProvider;

        public ValuesClient(IValuesProvider valuesProvider)
        {
            _valuesProvider = valuesProvider;
        }

        public Task<IEnumerable<string>> MakeRequest()
        {
            return _valuesProvider.FetchData();
        }
    }
}
