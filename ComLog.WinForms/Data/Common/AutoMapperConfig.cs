using AutoMapper.Configuration;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces;

namespace ComLog.WinForms.Data.Common
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountDto, AccountDto>()
                   ;
            cfg.CreateMap<AccountDto, IAccountView>()
                .ForMember(dest => dest.BankAccountName, opt => opt.MapFrom(src => src.Name))
                ;
            cfg.CreateMap<IAccountView, AccountDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BankAccountName))
                ;

            cfg.CreateMap<AccountTypeDto, AccountTypeDto>()
                   ;
            cfg.CreateMap<AccountTypeDto, IAccountTypeView>()
                .ForMember(dest => dest.AccountTypeName, opt => opt.MapFrom(src => src.Name))
                ;
            cfg.CreateMap<IAccountTypeView, AccountTypeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AccountTypeName))
                ;


            cfg.CreateMap<BankDto, BankDto>()
                ;
            cfg.CreateMap<BankDto, IBankView>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Name))
                ;
            cfg.CreateMap<IBankView, BankDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BankName))
                ;

            cfg.CreateMap<CurrencyDto, CurrencyDto>()
                ;
            cfg.CreateMap<CurrencyDto, ICurrencyView>()
                ;
            cfg.CreateMap<ICurrencyView, CurrencyDto>()
                ;

            cfg.CreateMap<TransactionTypeDto, TransactionTypeDto>()
                ;
            cfg.CreateMap<TransactionTypeDto, ITransactionTypeView>()
                .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.Name))
                ;
            cfg.CreateMap<ITransactionTypeView, TransactionTypeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TransactionTypeName))
                ;

            cfg.CreateMap<TransactionExtDto, TransactionExtDto>()
                ;
            cfg.CreateMap<TransactionExtDto, ITransactionView>()
                ;
            cfg.CreateMap<ITransactionView, TransactionExtDto>()
                ;
        }
    }
}