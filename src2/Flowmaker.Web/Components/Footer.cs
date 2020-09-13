using Flowmaker.ViewModels;
using Flowmaker.ViewModels.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Flowmaker.Web.Components
{
    public class Footer : ViewComponent
    {
        ViewModelMapperService _mapperService;
        public Footer(ViewModelMapperService mapperService)
        {
            _mapperService = mapperService;
        }
        //public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        public IViewComponentResult Invoke()
        {
            return View(_mapperService.ToFooterVm(ViewData.Model as ViewModelObject));
        }
    }
}
