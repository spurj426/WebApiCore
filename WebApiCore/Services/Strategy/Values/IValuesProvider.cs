using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesProvider
    {
        IEnumerable<string> MakeRequest();
    }
}
