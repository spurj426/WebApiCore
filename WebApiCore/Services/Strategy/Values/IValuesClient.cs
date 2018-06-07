using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesClient
    {
        IEnumerable<string> MakeRequest();
    }
}
