using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCore.Interfaces
{
    public interface IValuesService
    {
        Task<IEnumerable<string>> GetValues();
    }
}
