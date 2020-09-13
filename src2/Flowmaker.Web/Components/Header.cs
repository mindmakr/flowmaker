using Flowmaker.ViewModels;
using Flowmaker.ViewModels.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Flowmaker.Web.Components
{
    public class Header : ViewComponent
    {
        ViewModelMapperService _mapperService;
        public Header(ViewModelMapperService mapperService)
        {
            _mapperService = mapperService;
        }
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View(_mapperService.ToHeaderVm(ViewData.Model as ViewModelObject));
        }
    }
}
