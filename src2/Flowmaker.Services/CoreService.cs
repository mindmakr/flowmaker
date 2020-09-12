using Flowmaker.Data;
using Flowmaker.ViewModels.Mappers;
using Flowmaker.ViewModels.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowmaker.Services
{
    public class CoreService
    {
        private readonly ILogger<CoreService> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly ViewModelMapperService _vmms;
        public CoreService(ApplicationDbContext dbContext, ILogger<CoreService> logger, ViewModelMapperService vmms)
        {
            _vmms = vmms;
            _logger = logger;
            _dbContext = dbContext;
        }

        public HomepageVm GetHomepageVm(string hostname,string path)
        {
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            var flow = _dbContext.Flows.FirstOrDefault(f => f.Slug == path);
            if (flow == null) return null;
            var vm = new HomepageVm { Environment = _vmms.ToEnvironmentVm(slot), RequestRoute = path, FlowTitle = flow != null ? flow.Title : "NOT FOUND" };
            return vm;
        }
        
        public PrivacyVm GetPrivacyVm(string hostname)
        {
            var slot = _dbContext.Slots.Include(t => t.Workspace).FirstOrDefault(s => hostname == s.Hostname.ToLower());
            return new PrivacyVm { Environment = _vmms.ToEnvironmentVm(slot) };
        }
    }
}
