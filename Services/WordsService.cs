using System.Collections.Concurrent;
using Cyolo.Models;

namespace Cyolo.Services
{
    public class WordsService : IWordsService
    {
        protected ConcurrentDictionary<string, int> _wordsRepo;
        private StatsService _statService;

        public WordsService() 
        {
            _wordsRepo = new ConcurrentDictionary<string, int>();
            _statService = new StatsService(_wordsRepo);
        }

        public async Task WriteWords(string words)
        {
            var wordsArr = words.Split(',');

            var loopResult = await Task.Run(() => Parallel.ForEach(wordsArr, WriteWord));

            if (!loopResult.IsCompleted)
            {
                throw new Exception($"There were some errors in writing data from iteration {loopResult.LowestBreakIteration}");
            }
        }

        public async Task<Result> GetStats()
        {
           var result = await Task.Run(_statService.GetStats);

           return result; 
        }

        private void WriteWord(string s)
        {
            if (_wordsRepo.ContainsKey(s))
            {
                _wordsRepo[s]++;
            }
            else
            {
                _wordsRepo[s] = 1;
            }
        }
    }
}
