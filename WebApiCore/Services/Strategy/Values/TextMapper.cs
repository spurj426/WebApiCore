using System.Collections.Generic;
using System.Linq;

namespace WebApiCore.Services.Strategy.Values
{
    public class TextMapper : IValuesMapper
    {
        public IEnumerable<string> MapResponse(object input)
        {
            var response = input.ToString();

            var values = response.Split(System.Environment.NewLine);

            return values.AsEnumerable();
        }
    }
}
