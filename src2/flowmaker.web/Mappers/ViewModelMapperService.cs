using AutoMapper;
using flowmaker.models;
using flowmaker.web.ViewModels;

namespace flowmaker.web.Mappers
{
    public class ViewModelMapperService
    {
        private readonly IMapper _mapper;
        public ViewModelMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Environment From(Slot slot)
        {
            return slot == null
            ? new Environment { IsAvailable = false }
            : _mapper.Map<Environment>(slot);
        }
    }
}
