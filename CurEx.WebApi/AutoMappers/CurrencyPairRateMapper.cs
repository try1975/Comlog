using AutoMapper.Configuration;
using CurEx.Db.Entities.Entities;
using CurEx.Dto.Dto;

namespace CurEx.WebApi.AutoMappers
{
    public static class CurrencyPairRateMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CurrencyPairRateEntity, CurrencyPairRateDto>()
                ;
            cfg.CreateMap<CurrencyPairRateDto, CurrencyPairRateEntity>()
                ;
        }
    }
}