using CurEx.Db.Entities.Entities;
using CurEx.Db.Entities.QueryProcessors;
using CurEx.Dto.Dto;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Maintenance.Classes
{
    public class CurrencyPairApi : TypedApi<CurrencyPairDto, CurrencyPairEntity, string>, ICurrencyPairApi
    {
        public CurrencyPairApi(ICurrencyPairQuery query) : base(query)
        {
        }
    }
}