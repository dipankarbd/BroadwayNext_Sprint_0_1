using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BroadwayNextWeb.Data;
using BroadwayNextWeb.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace BroadwayNextWeb.Data
{

    public class EFRepository<TEntity> where TEntity : class
    {
        internal TGFContext context;
        internal DbSet<TEntity> dbSet;

        public EFRepository(TGFContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        //Call this for paging capability
        public virtual IEnumerable<TEntity> Get(out int rowCount,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int pageSize = 10, int currentPage = 1)
        {
            IQueryable<TEntity> query = dbSet;
            rowCount = 0;


            if (filter != null)
            {
                query = query.Where(filter);
            }
            //get the rowCount
            rowCount = query.Count();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        //--
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                dbSet.Add(entity);
            }
        }

        public virtual void Delete(object id)
        {
            var entity = GetByID(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            DbEntityEntry dbEntityEntry = context.Entry(entityToDelete);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbSet.Attach(entityToDelete);
                dbSet.Remove(entityToDelete);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbEntityEntry dbEntityEntry = context.Entry(entityToUpdate);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(entityToUpdate);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();

        }
    }

}