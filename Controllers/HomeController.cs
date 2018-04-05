using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        /// <summary>
        /// This is a test API call that will return the word that is passed.
        /// </summary>
        /// <param name="word">
        /// The word you want to return.
        /// </param>
        /// <remarks>
        /// </remarks>
        [HttpGet("Home", Name = "GetWord")]
        [SwaggerOperation("GetWord")]
        public async Task<IActionResult> GetWord(string word)
        {
            return Ok(word);
        }
    }
}