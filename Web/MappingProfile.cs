using AutoMapper;
using Domain.Entities;
using Shared.DataTransferObjects;

namespace Web
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        { 
            CreateMap<GraphicCard, GraphicCardDto>().ForCtorParam("FullModel", opt => opt.MapFrom(x => string.Join(' ', x.Manufacture, x.Power)));
            CreateMap<Processor, ProcessorDto>().ForCtorParam("FullModel", opt => opt.MapFrom(x => string.Join(' ', x.Manufacture, x.Model)));
        }
    }

}

