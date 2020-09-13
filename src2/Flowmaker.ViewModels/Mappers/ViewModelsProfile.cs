using AutoMapper;
using Flowmaker.Entities;
using Flowmaker.ViewModels.Components;

namespace Flowmaker.ViewModels.Mappers
{
    // This is the approach starting with version 5
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<Project, ProjectVm>();
            CreateMap<Environment, EnvironmentVm>();
            CreateMap<Flow, FlowVm>();
            CreateMap<ViewPage, ViewPageVm>();
        }
    }
}
