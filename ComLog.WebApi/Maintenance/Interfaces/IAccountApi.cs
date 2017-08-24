using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;

namespace ComLog.WebApi.Maintenance.Interfaces
{
    public interface IAccountApi : ITypedApi<AccountDto, int>
    {
        IEnumerable<AccountExtDto> GetExtItems();
    }
}