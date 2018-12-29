using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WebApiCore.Services.Mappers.Values
{
    /// <summary>
    /// The json mapper has a schema dependency which must be known in advance.
    /// </summary>
    public class JsonMapper : IValuesMapper
    {
        public IEnumerable<string> MapResponse(object input)
        {
            List<string> values = new List<string>();

            var response = JObject.Parse(input.ToString());

            foreach (var jprop in response.Properties())
            {
                values.Add(jprop.Value.ToString());
            }

            return values;
        }
    }
}
