using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public class JsonClient : IValuesClient
    {
        private readonly IValuesProvider _valuesProvider;

        public JsonClient(IValuesProvider valuesProvider)
        {
            _valuesProvider = valuesProvider;
        }

        public IEnumerable<string> MakeRequest()
        {
            return _valuesProvider.FetchData();
        }

    }
}
