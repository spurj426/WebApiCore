using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public class XmlClient : IValuesClient
    {
        private readonly IValuesProvider _valuesProvider;

        public XmlClient(IValuesProvider valuesProvider)
        {
            _valuesProvider = valuesProvider;
        }

        public IEnumerable<string> MakeRequest()
        {
            return _valuesProvider.FetchData();
        }
    }
}
