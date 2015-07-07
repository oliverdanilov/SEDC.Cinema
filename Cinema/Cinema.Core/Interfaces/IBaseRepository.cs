﻿using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Save();
        List<TEntity> GetBy(Expression<Func<TEntity, bool>> where);

    }
}
