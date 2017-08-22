using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class CurrencyAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CurrencyEntity, CurrencyDto>()
                ;
            cfg.CreateMap<CurrencyDto, CurrencyEntity>()
                ;
        }
    }
}