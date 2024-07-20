using AutoMapper;
using Hulk.Core.Dtos.BrokerDtos;
using Hulk.Data.Entities;

namespace Hulk.Core.Mapping
{
    public class BrokerAutoMapperProfile : Profile
    {
        public BrokerAutoMapperProfile() 
        {
            CreateMap<BrokerCreateRequestDto, Broker>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CurrentAmount, opt => opt.MapFrom(src => src.CurrentAmount))
                .ForMember(dest => dest.InitialAmount, opt => opt.MapFrom(src => src.InitialAmount));

            CreateMap<BrokerUpdateDto, Broker>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CurrentAmount, opt => opt.MapFrom(src => src.CurrentAmount))
                .ForMember(dest => dest.InitialAmount, opt => opt.MapFrom(src => src.InitialAmount));

            CreateMap<Broker, BrokerResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.CurrentAmount, opt => opt.MapFrom(src => src.CurrentAmount))
               .ForMember(dest => dest.InitialAmount, opt => opt.MapFrom(src => src.InitialAmount));

            CreateMap<Broker, BrokerMinimalResponseDto>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
