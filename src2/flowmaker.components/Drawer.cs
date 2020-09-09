
using Microsoft.AspNetCore.Mvc;


namespace flowmaker.components
{
    public class Drawer : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            {               
                return View();
            }
        }
    }
}
