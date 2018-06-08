using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCore.Services.Strategy.Values
{
    public class XmlClient : IValuesClient
    {
        private readonly IValuesProvider _valuesProvider;

        public XmlClient(IValuesProvider valuesProvider)
        {
            _valuesProvider = valuesProvider;
        }

        public Task<IEnumerable<string>> MakeRequest()
        {
            return _valuesProvider.FetchData();
        }
    }
}
