using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponentPartials
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
