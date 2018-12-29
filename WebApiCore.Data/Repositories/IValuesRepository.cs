using System.Threading.Tasks;

namespace WebApiCore.Data.Repositories
{
    public interface IValuesRepository
    {
        Task<object> GetValuesFromFileSystem(string fullFileName);
    }
}
