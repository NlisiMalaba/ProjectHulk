using AutoMapper;
using Hulk.Core.Dtos.TradeLogDtos;
using Hulk.Data.Entities;

namespace Hulk.Core.Mapping
{
    public class TradeLogAutoMapperPRofile : Profile
    { 
        public TradeLogAutoMapperPRofile()
        {
            CreateMap<TradeLogCreateRequestDto, TradeLog>()
                .ForMember(dest => dest.PairId, opt => opt.MapFrom(src => src.PairId))
                .ForMember(dest => dest.BrokerId, opt => opt.MapFrom(src => src.BrokerId))
                .ForMember(dest => dest.LotSize, opt => opt.MapFrom(src => src.LotSize))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.DateOfExecution, opt => opt.MapFrom(src => src.DateOfExecution))
                .ForMember(dest => dest.DateOfExit, opt => opt.MapFrom(src => src.DateOfExit))
                .ForMember(dest => dest.RewardToRisk, opt => opt.MapFrom(src => src.RewardToRisk))
                .ForMember(dest => dest.StopLossPips, opt => opt.MapFrom(src => src.StopLossPips))
                .ForMember(dest => dest.TakeProfitPips, opt => opt.MapFrom(src => src.TakeProfitPips))
                .ForMember(dest => dest.Profit, opt => opt.MapFrom(src => src.Profit))
                .ForMember(dest => dest.IsSuccessful, opt => opt.MapFrom(src => src.IsSuccessful))
                .ForMember(dest => dest.TradeType, opt => opt.MapFrom(src => src.TradeTypeName))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));

            CreateMap<TradeLogUpdateDto, TradeLog>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.PairId, opt => opt.MapFrom(src => src.PairId))
               .ForMember(dest => dest.BrokerId, opt => opt.MapFrom(src => src.BrokerId))
               .ForMember(dest => dest.LotSize, opt => opt.MapFrom(src => src.LotSize))
               .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
               .ForMember(dest => dest.DateOfExecution, opt => opt.MapFrom(src => src.DateOfExecution))
               .ForMember(dest => dest.DateOfExit, opt => opt.MapFrom(src => src.DateOfExit))
               .ForMember(dest => dest.RewardToRisk, opt => opt.MapFrom(src => src.RewardToRisk))
               .ForMember(dest => dest.StopLossPips, opt => opt.MapFrom(src => src.StopLossPips))
               .ForMember(dest => dest.TakeProfitPips, opt => opt.MapFrom(src => src.TakeProfitPips))
               .ForMember(dest => dest.Profit, opt => opt.MapFrom(src => src.Profit))
               .ForMember(dest => dest.IsSuccessful, opt => opt.MapFrom(src => src.IsSuccessful))
               .ForMember(dest => dest.TradeType, opt => opt.MapFrom(src => src.TradeTypeName))
               .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));

            CreateMap<TradeLog, TradeLogResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.PairId, opt => opt.MapFrom(src => src.PairId))
               .ForMember(dest => dest.BrokerId, opt => opt.MapFrom(src => src.BrokerId))
               .ForMember(dest => dest.LotSize, opt => opt.MapFrom(src => src.LotSize))
               .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
               .ForMember(dest => dest.DateOfExecution, opt => opt.MapFrom(src => src.DateOfExecution))
               .ForMember(dest => dest.DateOfExit, opt => opt.MapFrom(src => src.DateOfExit))
               .ForMember(dest => dest.RewardToRisk, opt => opt.MapFrom(src => src.RewardToRisk))
               .ForMember(dest => dest.StopLossPips, opt => opt.MapFrom(src => src.StopLossPips))
               .ForMember(dest => dest.TakeProfitPips, opt => opt.MapFrom(src => src.TakeProfitPips))
               .ForMember(dest => dest.Profit, opt => opt.MapFrom(src => src.Profit))
               .ForMember(dest => dest.IsSuccessful, opt => opt.MapFrom(src => src.IsSuccessful))
               .ForMember(dest => dest.TradeTypeName, opt => opt.MapFrom(src => src.TradeType))
               .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));


        }
    }
}
