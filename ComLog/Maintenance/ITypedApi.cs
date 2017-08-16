using System.Collections.Generic;
using ComLog.Dto;

namespace ComLog.Maintenance
{
    public interface ITypedApi<T, K> where T : class, IDto<K>
    {
        IEnumerable<T> GetItems();
        T GetItem(K id);
        T AddItem(T dto);
        T ChangeItem(T dto);
        bool RemoveItem(K id);
    }
}