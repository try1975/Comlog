using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class BankAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BankEntity, BankDto>()
                ;
            cfg.CreateMap<BankDto, BankEntity>()
                ;
        }
    }
}