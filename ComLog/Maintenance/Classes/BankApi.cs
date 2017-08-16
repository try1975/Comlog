using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.Maintenance
{
    public class BankApi : TypedApi<BankDto, BankEntity, int>, IBankApi
    {
        public BankApi(IBankQuery query) : base(query)
        {
        }
    }
}