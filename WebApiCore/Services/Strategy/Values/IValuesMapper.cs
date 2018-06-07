using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesMapper
    {
        IEnumerable<string> MapResponse(object input);
    }
}
