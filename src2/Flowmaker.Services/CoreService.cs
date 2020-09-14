using AutoMapper;
using Flowmaker.Data;
using Flowmaker.ViewModels.Components;
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
        private readonly IMapper _mapper;
        
        public CoreService(ApplicationDbContext dbContext, ILogger<CoreService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public FlowmakerPageVm GetFlowmakerPageViewModel(string hostname, string path)
        {
            // A Project and Env (that is editable is minimum)
            var env = _dbContext.Environments.Include(t => t.Project).FirstOrDefault(s => hostname == s.Hostname.ToLower() && !s.Disabled);
            if (env == null) return  new FlowmakerPageVm { RequestRoute = path};
            // Get list of flows under the host for the given path is. 
            var flows = _dbContext.Flows.Include(f => f.ViewPage).OrderBy(o => o.DisplayOrder).Where(f => f.EnvironmentId == env.Id && !f.Disabled && (f.Slug == path || f.ParentSlug == path)).ToList();
            // Build Page level data
            var vm = new FlowmakerPageVm
            {
                RequestRoute = path,
                Environment = _mapper.Map<EnvironmentVm>(env),
                Project = _mapper.Map<ProjectVm>(env.Project),
                Flows = _mapper.Map<IEnumerable<FlowVm>>(flows)
            };
            if (env.IsEditable)
            {
                var envs = _dbContext.Environments.Include(t => t.Project).Where(s => env.ProjectId == s.ProjectId && !s.Disabled).ToList();
                vm.Editor = new EditorVm { Environment = vm.Environment, Flows = vm.Flows, Project = vm.Project,RequestRoute = vm.RequestRoute };
                vm.Editor.Flow = vm.Flows.Any(f => f.Slug == vm.RequestRoute) ? vm.Flows.FirstOrDefault(f => f.Slug == vm.RequestRoute) : null;
                vm.Editor.Environments = _mapper.Map<IEnumerable<EnvironmentVm>>(envs);
            }
            return vm;
        }
    }
}
