using GnomURL.Server.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GnomURL.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("G/{shortURL}")]
        public IActionResult Index(string shortURL)
        {
            var result = InMemoryURLMap.Instance.GetURLFromShort(shortURL);

            if (result != null)
            {
                return Redirect("https://" + result.LongURL);
            }

            return NotFound();
        }
    }
}
