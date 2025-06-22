using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
