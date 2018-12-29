using System;
using System.IO;
using WebApiCore.Services.Providers;
using Xunit;

namespace WebApiCore.Tests
{
    public class FileSystemProviderTests
    {
        [Fact] 
        public async void FileSystemProvider_MissingFilePath_ThrowsArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => new FileSystemProvider().FetchData(string.Empty));
        }

        [Fact] 
        public async void FileSystemProvider_IncorrectFilePath_ThrowsFileNotFoundException()
        {
            await Assert.ThrowsAsync<FileNotFoundException>(() => new FileSystemProvider().FetchData(@"C:\FileNotFound.png"));
        }
    }
}
