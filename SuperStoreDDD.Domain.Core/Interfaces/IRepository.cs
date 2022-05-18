namespace SuperStoreDDD.Domain.Core.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : class
{
    IUnitOfWork UnitOfWork { get; }
    Task<IQueryable<TEntity>> ObterTodos();
    Task<TEntity> ObterPorID<TId>(TId id);
    Task<TEntity> Adicionar(TEntity entity);
    Task Remover(TEntity entity);
    Task<TEntity> Atualizar(TEntity entity);

    // Task<TEntity> GetById<TId>(TId id);
    // Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria);
    // Task<IList<TEntity>> GetMultiple(Expression<Func<TEntity, bool>> criteria);
    // Task<IList<TEntity>> GetAll();
    // Task<TEntity> Add(TEntity entity);
    // Task<TEntity> Update(TEntity entity);
    // Task Delete(TEntity entity);
}