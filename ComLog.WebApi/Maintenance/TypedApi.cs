using System.Collections.Generic;
using AutoMapper;
using ComLog.Db.Entities;
using ComLog.Dto;

namespace ComLog.WebApi.Maintenance
{
    public abstract class TypedApi<TV, TD, TK> : ITypedApi<TV, TK> where TD : class, IEntity<TK> where TV : class, IDto<TK>
    {
        protected readonly ITypedQuery<TD, TK> Query;
        //protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected TypedApi(ITypedQuery<TD, TK> query)
        {
            Query = query;
        }

        public virtual IEnumerable<TV> GetItems()
        {
            var list = Query.GetEntities();
            return Mapper.Map<List<TV>>(list);
        }

        public TV GetItem(TK id)
        {
            return Mapper.Map<TV>(Query.GetEntity(id));
        }

        public virtual TV AddItem(TV dto)
        {
            var entity = Mapper.Map<TD>(dto);
            return Mapper.Map<TV>(Query.InsertEntity(entity));
        }

        public virtual TV ChangeItem(TV dto)
        {
            var entity = Mapper.Map<TD>(dto);
            return Mapper.Map<TV>(Query.UpdateEntity(entity));
        }

        public virtual bool RemoveItem(TK id)
        {
            return Query.DeleteEntity(id);
        }
    }
}