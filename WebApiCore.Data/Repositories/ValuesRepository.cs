using System.Threading.Tasks;
using WebApiCore.Services.Providers;

namespace WebApiCore.Data.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly IFileSystemProvider _fileSystemProvider;

        public ValuesRepository(IFileSystemProvider fileSystemProvider)
        {
            _fileSystemProvider = fileSystemProvider;
        }

        public async Task<object> GetValuesFromFileSystem(string fullFileName)
        {
            return await _fileSystemProvider.FetchData(fullFileName);
        }
    }
}
