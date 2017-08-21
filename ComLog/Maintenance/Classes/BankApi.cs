using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.Maintenance
{
    public class BankApi : TypedApi<BankDto, BankEntity, int>, IBankApi
    {
        public BankApi(IBankQuery query) : base(query)
        {
        }
    }
}