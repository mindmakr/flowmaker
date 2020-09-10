
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Flowmaker.Web.Data;
using Flowmaker.Web.Mappers;
using Flowmaker.Web.Models;
using Flowmaker.Web.ViewModels;

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
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return View(new Homepage { Environment = _vmms.From(slot) });
        }

        public IActionResult Privacy()
        {
            var hostname = Request.Host.Host.ToLower();
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return View(new Privacy { Environment = _vmms.From(slot) });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
