using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.Dto.Ext;

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

            cfg.CreateMap<AccountEntity, AccountExtDto>()
               .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
               .ForMember(dest => dest.AccountTypeName, opt => opt.MapFrom(src => src.AccountType.Name))
                //.ForMember(dest => dest.CurrencyOrd, opt => opt.MapFrom(src => src.Currency.Ord))
               ;
            cfg.CreateMap<AccountExtDto, AccountEntity>()
               ;
        }
    }
}