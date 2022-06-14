using Microsoft.EntityFrameworkCore;
using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Infra.Data.Context;

namespace SuperStoreDDD.Infra.Data.Repositories.Base;

public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>,
                                           IDisposable
                                           where TEntity : class
                                           where TId : struct

{
    public IUnitOfWork UnitOfWork => _context;
    private readonly DataContext _context;

    public RepositoryBase(DataContext dbContext)
    {
        _context = dbContext;
    }

    public TEntity Adicionar(TEntity entity)
    {
        return _context.Set<TEntity>().Add(entity).Entity;
    }

    public TEntity Atualizar(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Modified;
        return entity;
    }

    public void Remover(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task<TEntity> ObterPorID(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> ObterTodos()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}