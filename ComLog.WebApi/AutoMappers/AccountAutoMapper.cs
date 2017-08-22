using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class AccountAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountEntity, AccountDto>()
                ;
            cfg.CreateMap<AccountDto, AccountEntity>()
                ;
        }
    }
}