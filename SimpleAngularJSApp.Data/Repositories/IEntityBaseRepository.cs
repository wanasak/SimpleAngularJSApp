﻿using SimpleAngularJSApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAngularJSApp.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predict);
        T GetSingle(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
