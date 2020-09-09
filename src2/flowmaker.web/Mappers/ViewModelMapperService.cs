using AutoMapper;
using flowmaker.models;

namespace flowmaker.components.ViewModels
{
    public class ViewModelMapperService
    {
        private readonly IMapper _mapper;
        public ViewModelMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Homepage From(Slot slot)
        {
            var homepage = new Homepage
            {
                Environment = slot == null
                ? new Environment { IsAvailable = false }
                : _mapper.Map<Environment>(slot)
            };
            return homepage;
        }
    }
}
