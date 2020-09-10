using AutoMapper;
using Flowmaker.Data.Entities;
using Flowmaker.Web.ViewModels;

namespace Flowmaker.Web.Mappers
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
