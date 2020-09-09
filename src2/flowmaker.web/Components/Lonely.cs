using Microsoft.AspNetCore.Mvc;

namespace flowmaker.web.Components
{
    public class Lonely : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
