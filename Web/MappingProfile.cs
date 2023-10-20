using AutoMapper;
using Domain.Entities;
using Shared.DataTransferObjects;

namespace Web
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        { 
            CreateMap<GraphicCard, GraphicCardDto>().ForCtorParam("FullModel", opt => opt.MapFrom(x => string.Join(' ', x.Manufacture, x.GpuName)));
            //CreateMap<GraphicCard, GraphicCardDto>().ForCtorParam("FullVram", opt => opt.MapFrom(x => string.Join(' ', x.VramType, x.Vram)));
            CreateMap<Processor, ProcessorDto>().ForCtorParam("FullModel", opt => opt.MapFrom(x => string.Join(' ', x.Manufacture, x.Model)));
        }
    }

}

