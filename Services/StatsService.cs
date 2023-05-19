using System.Collections.Concurrent;
using System.Text;
using Cyolo.Models;

namespace Cyolo.Services
{
    internal class StatsService
    {
        protected ConcurrentDictionary<string, int> _wordsRepo;
        protected SortedDictionary<int, List<string>> _statsRepo = new();
        public StatsService(ConcurrentDictionary<string, int> wordsRepo) 
        { 
            _wordsRepo = wordsRepo;
        }

        public Result GetStats()
        {
            var average = _wordsRepo.Average(w => w.Value);
            var ordered = _wordsRepo.OrderByDescending(w => w.Value);

            int n = 5;
            var topNPairs = ordered.Take(n);

            var result = new Result
            {
                Top5 = GetTopNString(topNPairs),
                Min = ordered.TakeLast(1).First().Value,
                Average = average
            };

            return result;
        }

        private static string GetTopNString(IEnumerable<KeyValuePair<string, int>> topNPairs)
        {
            var sb = new StringBuilder();
            foreach (var word in topNPairs)
            {
                sb.Append(word.Key).Append(": ").Append(word.Value).Append(" ");
            }

            return sb.ToString();
        }
    }
}
