using Challenge.WebApi.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Challenge.WebApi.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWebHostEnvironment _environment;

        public WriterService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task WriteToFileAsync(string inputText, string fileName)
        {
            await using var outputFile = new StreamWriter(Path.Combine(_environment.WebRootPath, fileName));
            await outputFile.WriteLineAsync(inputText);
        }
    }
}