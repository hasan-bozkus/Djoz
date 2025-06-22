using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorsController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
