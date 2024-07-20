using AutoMapper;
using Hulk.Core.Dtos.PairDtos;
using Hulk.Data.Entities;


namespace Hulk.Core.Mapping
{
    public class PairAutoMapperProfile : Profile
    {
        public PairAutoMapperProfile() 
        { 
            CreateMap<PairCreateRequestDto, Pair>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfTrades, opt => opt.MapFrom(src => src.NumberOfTrades));

            CreateMap<PairUpdateDto, Pair>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfTrades, opt => opt.MapFrom(src => src.NumberOfTrades));

            CreateMap<Pair, PairResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NumberOfTrades, opt => opt.MapFrom(src => src.NumberOfTrades));

            CreateMap<Pair, PairMinimalResponseDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }  
    }
}
