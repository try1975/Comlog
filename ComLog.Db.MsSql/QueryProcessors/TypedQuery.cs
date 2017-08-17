﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public abstract class TypedQuery<T, TK> : ITypedQuery<T, TK> where T : class, IEntity<TK>
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _entities;

        protected TypedQuery(DbContext db)
        {
            _db = db;
            _entities = _db.Set<T>();
        }

        public virtual IQueryable<T> GetEntities()
        {
            return _entities.AsNoTracking();
        }

        public virtual T GetEntity(TK id)
        {
            var entity = _entities.Find(id);
            return entity;
        }

        public async Task<T> GetEntityAsync(TK id)
        {
            return await _entities.FindAsync(id);
        }

        public T InsertEntity(T entity)
        {
            using (var db = new WorkContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public T UpdateEntity(T entity)
        {
            using (var db = new WorkContext())
            {
                db.Set<T>().AddOrUpdate(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public bool DeleteEntity(TK id)
        {
            using (var db = new WorkContext())
            {
                var entity = db.Set<T>().Find(id);
                if (entity == null) return false;
                try
                {
                    db.Set<T>().Attach(entity);
                    db.Set<T>().Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
            }
        }

        public DbContext GetDbContext()
        {
            return _db;
        }
    }
}