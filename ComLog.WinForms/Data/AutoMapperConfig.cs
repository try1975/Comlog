using AutoMapper.Configuration;
using ComLog.Dto;
using ComLog.WinForms.Interfaces;

namespace ComLog.WinForms.Data
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BankDto, BankDto>()
                ;
            cfg.CreateMap<BankDto, IBankView>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Name))
                ;
            cfg.CreateMap<IBankView, BankDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BankName))
                ;

            //cfg.CreateMap<BankAccountDto, BankAccountDto>()
            //    ;
            //cfg.CreateMap<BankAccountDto, IBankAccountView>()
            //    .ForMember(dest => dest.BankAccountName, opt => opt.MapFrom(src => src.Name))
            //    ;
            //cfg.CreateMap<IBankAccountView, BankAccountDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BankAccountName))
            //    ;


            //cfg.CreateMap<AccountDto, AccountDto>()
            //    ;
            //cfg.CreateMap<AccountDto, IClientAccountView>()
            //    .ForMember(dest => dest.ClientAccountName, opt => opt.MapFrom(src => src.Name))
            //    ;
            //cfg.CreateMap<IClientAccountView, AccountDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClientAccountName))
            //    ;


            //cfg.CreateMap<TransactionDto, TransactionDto>()
            //    ;
            //cfg.CreateMap<TransactionDto, ITransactionView>()
            //    ;
            //cfg.CreateMap<ITransactionView, TransactionDto>()
            //    ;
        }
    }
}