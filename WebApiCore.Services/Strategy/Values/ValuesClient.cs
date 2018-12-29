using System.Threading.Tasks;
using WebApiCore.Data.Repositories;
using WebApiCore.Services.Mappers.Values;

namespace WebApiCore.Services.Strategy.Values
{
    public class ValuesClient : IValuesClient
    {
        private readonly IValuesRepository _valuesRepository;
        private readonly IValuesMapper _mapper;

        public ValuesClient(IValuesRepository valuesRepository, IValuesMapper mapper)
        {
            _valuesRepository = valuesRepository;
            _mapper = mapper;
        }

        public async Task<object> MakeRequest(string location)
        {
            var result = await _valuesRepository.GetValuesFromFileSystem(location);
            return _mapper.MapResponse(new[] {result});
        }
    }
}
