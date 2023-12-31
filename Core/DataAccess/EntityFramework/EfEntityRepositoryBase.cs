﻿using Entities.Concrete.DbEntities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
{
    protected TContext Context { get; }

    public EfEntityRepositoryBase(TContext context)
    {
        Context = context;
    }
    public TEntity Add(TEntity entity)
    {
        return Context.Add(entity).Entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Update(entity);

        return entity;
    }
    public void Delete(TEntity entity)
    {
        Context.Remove(entity);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        return Context.Set<TEntity>().FirstOrDefault(expression);
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return Context.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
    {
        return expression == null
            ? Context.Set<TEntity>().AsNoTracking()
            : Context.Set<TEntity>().Where(expression).AsNoTracking();
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        return expression == null
            ? await Context.Set<TEntity>().AsNoTracking().ToListAsync()
            : await Context.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return Context.SaveChangesAsync();
    }
}