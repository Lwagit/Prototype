using Microsoft.AspNetCore.Mvc;

namespace Prototype.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
