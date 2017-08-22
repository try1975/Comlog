using AutoMapper.Configuration;
using CurEx.Db.Entities.Entities;
using CurEx.Dto.Dto;

namespace CurEx.WebApi.AutoMappers
{
    public static class CurrencyPairMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CurrencyPairEntity, CurrencyPairDto>()
                ;
            cfg.CreateMap<CurrencyPairDto, CurrencyPairEntity>()
                ;
        }
    }
}