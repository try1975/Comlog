using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.Dto.Ext;

namespace ComLog.WebApi.AutoMappers
{
    public static class TransactionAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TransactionEntity, TransactionDto>()
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.Dt))
                ;
            cfg.CreateMap<TransactionDto, TransactionEntity>()
                .ForMember(dest => dest.Dt, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate))
                ;

            cfg.CreateMap<TransactionEntity, TransactionReport01Dto>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.TransactionType.Name))
                ;

            cfg.CreateMap<TransactionEntity, TransactionExtDto>()
               .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
               .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
               .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.TransactionType.Name))
               .ForMember(dest => dest.MsDaily01, opt => opt.MapFrom(src => src.Account.MsDaily01))
                .ForMember(dest => dest.CurrencyOrd, opt => opt.MapFrom(src => src.Currency.Ord))
               ;
            cfg.CreateMap<TransactionExtDto, TransactionEntity>()
               ;

        }
    }
}