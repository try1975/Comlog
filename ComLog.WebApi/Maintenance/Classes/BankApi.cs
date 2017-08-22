using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class BankApi : TypedApi<BankDto, BankEntity, int>, IBankApi
    {
        public BankApi(IBankQuery query) : base(query)
        {
        }
    }
}