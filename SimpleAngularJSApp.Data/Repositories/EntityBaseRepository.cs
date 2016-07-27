﻿using SimpleAngularJSApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAngularJSApp.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private SimpleAngularJSAppContext dbContext;

        protected SimpleAngularJSAppContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = new SimpleAngularJSAppContext());
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predict)
        {
            return DbContext.Set<T>().Where(predict);
        }
        public virtual T GetSingle(int id)
        {
            return GetAll().SingleOrDefault(t => t.ID == id);
        }
        public virtual void Add(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Added;
            DbContext.SaveChanges();
        }
        public virtual void Edit(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
    }
}
