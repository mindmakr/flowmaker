using flowmaker.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace flowmaker.components
{
    public class Lonely : ViewComponent
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
