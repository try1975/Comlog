using System.Collections.Generic;
using CurEx.Dto;

namespace CurEx.WebApi.Maintenance
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