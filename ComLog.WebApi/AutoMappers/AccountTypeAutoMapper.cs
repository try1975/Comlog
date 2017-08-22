using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class AccountTypeAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountTypeEntity, AccountTypeDto>()
                ;
            cfg.CreateMap<AccountTypeDto, AccountTypeEntity>()
                ;
        }
    }
}