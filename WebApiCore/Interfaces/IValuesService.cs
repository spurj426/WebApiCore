using System.Collections.Generic;

namespace WebApiCore.Interfaces
{
    public interface IValuesService
    {
        IEnumerable<string> GetValues();
    }
}
