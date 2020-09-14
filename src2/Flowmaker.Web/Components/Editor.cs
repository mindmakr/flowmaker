using Flowmaker.ViewModels;
using Flowmaker.ViewModels.Mappers;
using Flowmaker.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace Flowmaker.Web.Components
{
    public class Editor : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View((ViewData.Model as FlowmakerPageVm).Editor);
        }
    }
}
