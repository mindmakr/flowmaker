using Microsoft.AspNetCore.Mvc;

namespace Flowmaker.Web.Components
{
    public class Header : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
