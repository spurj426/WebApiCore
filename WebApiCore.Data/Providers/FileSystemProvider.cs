using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApiCore.Services.Providers
{
    /// <summary>
    /// Provides the actual implementation for making requests from the client.
    /// </summary>
    public class FileSystemProvider : IFileSystemProvider
    {
        public async Task<object> FetchData(string fullFileName)
        {
            try
            {
                using (var sr = new StreamReader(fullFileName))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (ArgumentException aex)
            {
                throw new ArgumentException(aex.Message);
            }
            catch (FileNotFoundException fex)
            {
                throw new FileNotFoundException(fex.Message);
            }
        }
    }
}
