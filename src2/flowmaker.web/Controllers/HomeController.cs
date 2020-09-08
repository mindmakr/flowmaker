
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using flowmaker.web.Models;
using flowmaker.web.Data;
using Microsoft.EntityFrameworkCore;
using flowmaker.components.ViewModels;
using AutoMapper;
using flowmaker.models;

namespace flowmaker.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var hostname = Request.Host.Host.ToLower();
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return View(_mapper.Map<HomepageViewModel>(slot==null?new Slot():slot));
        }

        public IActionResult Privacy()
        {
            var hostname = Request.Host.Host.ToLower();
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return View(_mapper.Map<HomepageViewModel>(slot == null ? new Slot() : slot));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
