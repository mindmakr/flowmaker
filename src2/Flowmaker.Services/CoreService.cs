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
        private readonly ViewModelMapperService _map;
        public CoreService(ApplicationDbContext dbContext, ILogger<CoreService> logger, ViewModelMapperService vmms)
        {
            _map = vmms;
            _logger = logger;
            _dbContext = dbContext;
        }

        public FlowmakerPageVm GetHomepageVm(string hostname, string path)
        {
            var vm = new FlowmakerPageVm();
            var env = _dbContext.Environments.Include(t => t.Project).FirstOrDefault(s => hostname == s.Hostname.ToLower() && !s.Disabled);
            if (env == null) return vm;
            var flows = _dbContext.Flows.Include(f => f.ViewPage).OrderBy(o => o.DisplayOrder).Where(f => f.EnvironmentId == env.Id && !f.Disabled && (f.Slug == path || f.ParentSlug == path)).ToList();
            if (env.Hostname.ToLower()==env.Project.EditableHostname.ToLower())
            {
                var envs = _dbContext.Environments.Include(t => t.Project).Where(s => env.ProjectId == s.ProjectId && !s.Disabled).ToList();
                return _map.ToFlowmakerPageVm(path, env, flows, envs);
            }
            return _map.ToFlowmakerPageVm(path, env, flows,null);
        }
    }
}
