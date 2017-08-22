using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class TransactionTypeAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TransactionTypeEntity, TransactionTypeDto>()
                ;
            cfg.CreateMap<TransactionTypeDto, TransactionTypeEntity>()
                ;
        }
    }
}