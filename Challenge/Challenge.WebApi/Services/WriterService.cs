using Challenge.WebApi.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Challenge.WebApi.Services
{
    public class WriterService : IWriterService
    {
        public async Task WriteToFileAsync(string inputText, string delimiter, string filePath)
        {
            await using var stringWriter = File.AppendText(filePath);
            await stringWriter.WriteAsync($"{inputText}{delimiter}");
        }
    }
}