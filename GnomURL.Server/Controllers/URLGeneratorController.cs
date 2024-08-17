using GnomURL.Server.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GnomURL.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLGeneratorController : ControllerBase
    {
        private readonly ILogger<URLGeneratorController> _logger;

        public URLGeneratorController(ILogger<URLGeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetURL")]
        public IActionResult GetURL(string shortURL)
        {
            var result = InMemoryURLMap.Instance.GetURLFromShort(shortURL);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        // TODO add URI valiation
        [HttpPost(Name = "PostGenerateURL")]
        public IActionResult PostGenerateURL(string longURL, string suggestedShortURL = "")
        {
            var result = InMemoryURLMap.Instance.AddGnomUrl(longURL, suggestedShortURL);

            if (result != "error")
            {
                return Ok(result);
            }

            return BadRequest("This URL is taken or URL is invalid");
        }

        [HttpPost(Name = "DeleteURL")]
        public IActionResult DeleteShortURL(string shortURL)
        {
            InMemoryURLMap.Instance.DeleteShortURL(shortURL);
            return Ok();
        }

        [HttpGet(Name = "GetCount")]
        public IActionResult GetCount(string shortURL)
        {
            var result = InMemoryURLMap.Instance.GetURLFromShort(shortURL, dontCount: true);
            if (result != null)
            {
                return Ok(result.Count);
            }

            return NotFound();
        }
    }
}
