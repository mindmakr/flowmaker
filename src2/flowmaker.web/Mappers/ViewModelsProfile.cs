using AutoMapper;
using Flowmaker.Domains;
using Flowmaker.Web.ViewModels;

namespace Flowmaker.Web.Mappers
{
    // This is the approach starting with version 5
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<Slot, Environment>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.WorkspaceName, act => act.MapFrom(src => src.Workspace.Name))
                .ForMember(dest => dest.IsAvailable, act => act.MapFrom(src => src != null))
                .ForMember(dest => dest.WorkspaceTitle, act => act.MapFrom(src => src.Workspace.Title));
        }
    }
}
