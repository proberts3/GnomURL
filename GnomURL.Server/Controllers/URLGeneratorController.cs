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

        [HttpGet(Name = "GetShortURL")]
        public string GetShortURL()
        {
            return "";
        }

        [HttpPost(Name = "PostGenerateURL")]
        public string PostGenerateURL(string suggestedShortURL = "")
        {
            return "";
        }

        [HttpPost(Name = "DeleteURL")]
        public string DeleteShortURL(string shortURL)
        {
            return "";
        }

    }
}
