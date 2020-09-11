using AutoMapper;
using Flowmaker.Entities;
using Flowmaker.ViewModels.Components;
using Flowmaker.ViewModels.Views;

namespace Flowmaker.ViewModels.Mappers
{
    public class ViewModelMapperService
    {
        private readonly IMapper _mapper;
        public ViewModelMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public EnvironmentVm ToEnvironmentVm(Environment slot)
        {
            return slot == null
            ? new EnvironmentVm { IsAvailable = false }
            : _mapper.Map<EnvironmentVm>(slot);
        }
        public EditorVm ToDrawerVm(ViewModelObject vm)
        {
            return new EditorVm { Environment = vm.Environment };
        }
    }
}
