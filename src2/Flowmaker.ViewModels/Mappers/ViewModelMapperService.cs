﻿using AutoMapper;
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

        public FlowmakerPageVm ToFlowmakerPageVm(string path, Environment env, IEnumerable<Flow> flows)
        {
            var vm = new FlowmakerPageVm
            {
                RequestPath = path,
                Environment = _mapper.Map<EnvironmentVm>(env),
                Project = _mapper.Map<ProjectVm>(env.Project),
                Flows = _mapper.Map<IEnumerable<FlowVm>>(flows)
            };
            vm.ViewPage = vm.Flows!=null && vm.Flows.Any(f=>f.Slug==path)? vm.Flows.FirstOrDefault(f => f.Slug == path).ViewPage:null;
            if (vm.IsEditable)
            {
                vm.Editor = new EditorVm { Environment = vm.Environment, Flows = vm.Flows, Project = vm.Project };
            }
            return vm;
        }
    }
}
