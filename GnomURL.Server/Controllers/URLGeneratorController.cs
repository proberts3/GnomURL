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

        [HttpPost(Name = "PostGenerateURL")]
        public string Post()
        {
            return "";
        }
    }
}
