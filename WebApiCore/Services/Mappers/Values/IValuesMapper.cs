using System.Collections.Generic;

namespace WebApiCore.Services.Mappers.Values
{
    public interface IValuesMapper
    {
        IEnumerable<string> MapResponse(object input);
    }
}
