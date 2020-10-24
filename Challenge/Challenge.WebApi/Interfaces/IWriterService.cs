using System.Threading.Tasks;

namespace Challenge.WebApi.Interfaces
{
    public interface IWriterService
    {
        Task WriteToFileAsync(string inputText, string fileName);
    }
}