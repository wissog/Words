using Cyolo.Models;

namespace Cyolo.Services
{
    public interface IWordsService
    {
        Task WriteWords(string words);

        Task<Result> GetStats();
    }
}
