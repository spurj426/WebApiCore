using System.Threading.Tasks;

namespace WebApiCore.Services
{
    public interface IValuesService
    {
        Task<object> GetValues(string location);
    }
}
