using Microsoft.AspNetCore.Mvc;

namespace Optik_Arayuz_UI.Controllers
{
    public class HelpController : Controller
    {
        private readonly ILogger<HelpController> _logger;

        public HelpController(ILogger<HelpController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
