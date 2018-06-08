using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesClient
    {
        Task<IEnumerable<string>> MakeRequest();
    }
}
