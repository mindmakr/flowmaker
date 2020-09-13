using AutoMapper;
using Flowmaker.Entities;
using Flowmaker.ViewModels.Components;
using Flowmaker.ViewModels.Views;
using System.Collections.Generic;
using System.Linq;

namespace Flowmaker.ViewModels.Mappers
{
    public class ViewModelMapperService
    {
        private readonly IMapper _mapper;
        public ViewModelMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public EnvironmentVm ToEnvironmentVm(Environment env)
        {
            return env == null
            ? new EnvironmentVm { }
            : _mapper.Map<EnvironmentVm>(env);
        }
        public EditorVm ToEditorVm(ViewModelObject vm)
        {
            if (vm == null) return null;
            return new EditorVm { Environment = vm.Environment };
        }

        public FooterVm ToFooterVm(ViewModelObject vm)
        {
            if (vm == null) return null;
            return new FooterVm { Environment = vm.Environment };
        }

        public HeaderVm ToHeaderVm(ViewModelObject vm)
        {
            if (vm == null) return null;
            return new HeaderVm { Environment = vm.Environment };
        }

        public FlowmakerPageVm ToFlowmakerPageVm(Environment env, IEnumerable<Flow> flows)
        {
            var vm = new FlowmakerPageVm
            {
                Environment = _mapper.Map<EnvironmentVm>(env),
                Project = _mapper.Map<ProjectVm>(env.Project),
                Flows = _mapper.Map<IEnumerable<FlowVm>>(flows)
            };
            if (vm.IsEditable)
            {
                vm.Editor = new EditorVm { Environment = vm.Environment, Flows = vm.Flows, Project = vm.Project };
            }
            if (vm.IsAvailable)
            {
                vm.Title = vm.Project.Title;
            }
            return vm;
        }
    }
}
