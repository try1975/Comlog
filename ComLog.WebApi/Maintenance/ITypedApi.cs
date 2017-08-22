using System.Collections.Generic;
using ComLog.Dto;

namespace ComLog.WebApi.Maintenance
{
    public interface ITypedApi<T, in TK> where T : class, IDto<TK>
    {
        IEnumerable<T> GetItems();
        T GetItem(TK id);
        T AddItem(T dto);
        T ChangeItem(T dto);
        bool RemoveItem(TK id);
    }
}