
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Flowmaker.ViewModels.Mappers;
using Flowmaker.Data;
using Flowmaker.ViewModels.Views;
using Microsoft.AspNetCore.Routing;

namespace Flowmaker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly ViewModelMapperService _vmms;
        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger, ViewModelMapperService vmms)
        {
            _vmms = vmms;
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var hostname = Request.Host.Host.ToLower();
            var path = Request.Headers[":path"].ToString().ToLower();
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            var flow = _dbContext.Flows.FirstOrDefault(f => f.Slug == path);
            if(flow==null) return NotFound();
            var vm = new HomepageVm { Environment = _vmms.ToEnvironmentVm(slot), RequestRoute= Request.Headers[":path"], FlowTitle = flow != null?flow.Title:"NOT FOUND" };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            var hostname = Request.Host.Host.ToLower();
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return View(new PrivacyVm { Environment = _vmms.ToEnvironmentVm(slot) });
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
