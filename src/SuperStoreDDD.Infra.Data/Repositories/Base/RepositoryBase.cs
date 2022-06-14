using Microsoft.EntityFrameworkCore;
using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Infra.Data.Context;

namespace SuperStoreDDD.Infra.Data.Repositories.Base;

public class RepositoryBase<TEntity,TId> : IRepository<TEntity, TId>,
                                           IDisposable
                                           where TEntity : class 
                                           where TId : struct 
                                           
{
    //public IUnitOfWork UnitOfWork;
    private readonly DataContext dbContext;

    public RepositoryBase(IUnitOfWork unitOfWork, DataContext dbContext)
    {
        //UnitOfWork = unitOfWork;
        this.dbContext = dbContext;
    }

    public TEntity Adicionar(TEntity entity)
    {
        return dbContext.Set<TEntity>().Add(entity).Entity;
    }

    public TEntity Atualizar(TEntity entity)
    {
        dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        return entity;
    }
    public void Remover(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
    }

    public TEntity ObterPorID(TId id)
    {
        return dbContext.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> ObterTodos()
    {
        return dbContext.Set<TEntity>().ToList();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}