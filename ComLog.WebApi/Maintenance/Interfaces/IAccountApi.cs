using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;

namespace ComLog.WebApi.Maintenance.Interfaces
{
    public interface IAccountApi : ITypedApi<AccountDto, int>
    {
        IEnumerable<AccountExtDto> GetExtItems(bool withBalance);
        IEnumerable<AccountMsDailyDto> GetMsDaily(DateTime? dateFrom = null, DateTime? dateTo = null);
    }
}