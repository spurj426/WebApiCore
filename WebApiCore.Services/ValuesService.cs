using System.Threading.Tasks;
using WebApiCore.Data.Repositories;

namespace WebApiCore.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesService(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }

        public Task<object> GetValues(string location)
        {
            return _valuesRepository.GetValuesFromFileSystem(location);
        }
    }
}
