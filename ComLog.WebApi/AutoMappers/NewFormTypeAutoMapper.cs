using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class NewFormTypeAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<NewFormTypeEntity, NewFormTypeDto>()
                ;
            cfg.CreateMap<NewFormTypeDto, NewFormTypeEntity>()
                ;
        }
    }
}