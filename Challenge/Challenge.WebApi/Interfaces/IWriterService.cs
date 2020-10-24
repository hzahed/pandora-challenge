using System.Threading.Tasks;

namespace Challenge.WebApi.Interfaces
{
    public interface IWriterService
    {
        /// <summary>
        /// Append input text to existing file or create it if it doesn't exist
        /// </summary>
        /// <param name="inputText">Input text</param>
        /// <param name="delimiter">Delimiter</param>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        Task WriteToFileAsync(string inputText, string delimiter, string filePath);
    }
}