using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.AutoMappers
{
    public static class TransactionAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TransactionEntity, TransactionDto>()
                ;
            cfg.CreateMap<TransactionDto, TransactionEntity>()
                ;

            cfg.CreateMap<TransactionEntity, TransactionReport01Dto>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.TransactionType.Name))
                ;
            
        }
    }
}