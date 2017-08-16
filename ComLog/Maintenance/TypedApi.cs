using System.Collections.Generic;
using AutoMapper;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.Maintenance
{
    public abstract class TypedApi<TV, D, K> : ITypedApi<TV, K> where D : class, IEntity<K> where TV : class, IDto<K>
    {
        protected readonly ITypedQuery<D, K> Query;
        //protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected TypedApi(ITypedQuery<D, K> query)
        {
            Query = query;
        }

        public virtual IEnumerable<TV> GetItems()
        {
            var list = Query.GetEntities();
            return Mapper.Map<List<TV>>(list);
        }

        public TV GetItem(K id)
        {
            return Mapper.Map<TV>(Query.GetEntity(id));
        }

        public virtual TV AddItem(TV dto)
        {
            var entity = Mapper.Map<D>(dto);
            return Mapper.Map<TV>(Query.InsertEntity(entity));
        }

        public virtual TV ChangeItem(TV dto)
        {
            var entity = Mapper.Map<D>(dto);
            return Mapper.Map<TV>(Query.UpdateEntity(entity));
        }

        public virtual bool RemoveItem(K id)
        {
            return Query.DeleteEntity(id);
        }
    }
}