using System.Threading.Tasks;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesClient
    {
        Task<object> MakeRequest(string location);
    }
}
