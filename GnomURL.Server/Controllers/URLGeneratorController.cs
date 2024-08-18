using GnomURL.Server.Persistence;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetURL([FromQuery(Name = "shortURL")] string shortURL)
        {
            var result = InMemoryURLMap.Instance.GetURLFromShort(shortURL, dontCount: true);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        public class GenURLReq
        {
            public string longURL { get; set; }
            public string suggestedShortURL { get; set; } = "";
        }

        // TODO add URI valiation
        [HttpPost(Name = "PostGenerateURL")]
        public IActionResult PostGenerateURL([FromBody] GenURLReq urlRequest)
        {
            var result = InMemoryURLMap.Instance.AddGnomUrl(urlRequest.longURL, urlRequest.suggestedShortURL);

            if (result != "error")
            {
                return new JsonResult(result);
            }

            return BadRequest("This URL is taken or URL is invalid");
        }

        public class ShortURLReq { public string shortURL { get; set; } }
        [HttpDelete(Name = "DeleteURL")]
        public IActionResult DeleteShortURL([FromBody] ShortURLReq req)
        {
            InMemoryURLMap.Instance.DeleteShortURL(req.shortURL);
            return Ok();
        }

        //[HttpGet(Name = "GetCount")]
        //public IActionResult GetCount(string shortURL)
        //{
        //    var result = InMemoryURLMap.Instance.GetURLFromShort(shortURL, dontCount: true);
        //    if (result != null)
        //    {
        //        return Ok(result.Count);
        //    }

        //    return NotFound();
        //}
    }
}
