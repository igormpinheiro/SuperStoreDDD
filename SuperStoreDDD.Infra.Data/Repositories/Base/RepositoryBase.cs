using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Infra.Data.Context;

namespace SuperStoreDDD.Infra.Data.Repositories.Base;

public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
{
    public IUnitOfWork UnitOfWork { get; set; }
    
    protected readonly DataContext DbContext;

    public RepositoryBase(DataContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public virtual async Task<IQueryable<TEntity>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> ObterPorID<TId>(TId id)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> Adicionar(TEntity entity)
    {
        // var obj = DbContext.Add(entity);
        //
        // await DbContext.SaveChangesAsync();
        //
        // return obj.Entity;

        return await DbContext.Set<TEntity>().Add(entity);
    }

    public async Task Remover(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> Atualizar(TEntity entity)
    {
        throw new NotImplementedException();
    }
}