using flowmaker.models;
using Microsoft.AspNetCore.Mvc;


namespace flowmaker.web.Components
{
    public class Login : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
