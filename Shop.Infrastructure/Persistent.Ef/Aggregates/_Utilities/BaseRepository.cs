﻿using Common.Domain.Repository;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ShopDbContext Context;
    public BaseRepository(ShopDbContext context)
    {
        Context = context;
    }

    public virtual async Task<TEntity?> GetAsync(Guid id)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<TEntity?> GetTracking(Guid id)
    {
        return await Context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

    }
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    void IBaseRepository<TEntity>.Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public async Task AddRange(ICollection<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
    }
    public void Update(TEntity entity)
    {
        Context.Update(entity);
    }
    public async Task<int> Save()
    {
        return await Context.SaveChangesAsync();
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Context.Set<TEntity>().AnyAsync(expression);
    }
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return Context.Set<TEntity>().Any(expression);
    }

    public TEntity? Get(Guid id)
    {
        return Context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
    }
}
