using flowmaker.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace flowmaker.components
{
    public class Login : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            {
                var items = new Flow { Name = "This is testing name", Title = "this is a testing title" };
                return View(items);
            }
        }
    }
}
