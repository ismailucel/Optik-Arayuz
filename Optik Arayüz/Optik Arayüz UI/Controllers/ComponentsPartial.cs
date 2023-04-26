using Microsoft.AspNetCore.Mvc;

namespace Optik_Arayüz_UI.Controllers
{
    public class ComponentsPartial : Controller
    {
        public IActionResult Logo()
        {
            return PartialView();
        }
        public IActionResult NumaraKodlama()
        {
            return PartialView();
        }
        public IActionResult OgrenciBilgiler()
        {
            return PartialView();
        }
        public IActionResult Puanlama()
        {
            return PartialView();
        }
        public IActionResult SikSecme()
        {
            return PartialView();
        }
        public IActionResult Text()
        {
            return PartialView();
        }
        public IActionResult Test()
        {
            return PartialView();
        }
    }
}
