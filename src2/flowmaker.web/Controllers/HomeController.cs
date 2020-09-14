
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Flowmaker.ViewModels.Mappers;
using Flowmaker.Data;
using Flowmaker.ViewModels.Views;
using Microsoft.AspNetCore.Routing;
using Flowmaker.Services;

namespace Flowmaker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoreService _service;
        public HomeController(ILogger<HomeController> logger, CoreService service)
        {
            _service = service;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var hostname = Request.Host.Host.ToLower();
            var path = Request.Headers[":path"].ToString().ToLower();
            var vm = _service.GetFlowmakerPageViewModel(hostname, path);
            return View("Index",vm);
        }

        public IActionResult Page404()
        {
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVm { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
