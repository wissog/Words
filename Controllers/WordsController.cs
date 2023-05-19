using Cyolo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cyolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsService _wordsService;
        
        public WordsController(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        [HttpPost]
        [Route("WriteWords")]
        public async Task<IActionResult> WriteWords(string words)
        {
            await Task.Run(() => _wordsService.WriteWords(words));

            return Ok();
        }

        [HttpGet]
        [Route("GetStats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _wordsService.GetStats();
            return Ok(stats);
        }
    }
}
