namespace SuperStoreDDD.Domain.Core.Interfaces;

public interface IRepository<TEntity, in TId> where TEntity : class where TId : struct
{
    IUnitOfWork UnitOfWork { get; }
    Task<IEnumerable<TEntity>> ObterTodos();
    Task<TEntity> ObterPorID(TId id);
    TEntity Adicionar(TEntity entity);
    void Remover(TEntity entity);
    TEntity Atualizar(TEntity entity);
    //void Dispose();

    //Task<IQueryable<TEntity>> ObterTodos();
    //Task<TEntity> ObterPorID<TId>(TId id);
    //Task<TEntity> Adicionar(TEntity entity);
    //Task Remover(TEntity entity);
    //Task<TEntity> Atualizar(TEntity entity);

    // Task<TEntity> GetById<TId>(TId id);
    // Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria);
    // Task<IList<TEntity>> GetMultiple(Expression<Func<TEntity, bool>> criteria);
    // Task<IList<TEntity>> GetAll();
    // Task<TEntity> Add(TEntity entity);
    // Task<TEntity> Update(TEntity entity);
    // Task Delete(TEntity entity);
}