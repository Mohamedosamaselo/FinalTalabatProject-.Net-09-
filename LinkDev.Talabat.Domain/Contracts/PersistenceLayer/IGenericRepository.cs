using LinkDev.Talabat.Application.Abstraction;

namespace LinkDev.Talabat.Domain.Contracts.PersistenceLayer;

public interface IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);

    Task<TEntity?> GetAsync(TKey id);

    // Specification Design Pattern
    Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity, TKey> specification);

    Task<TEntity?> GetWithSpecAsync(ISpecification<TEntity, TKey> specification);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> AnyAsync(TKey id);

    Task<int> SaveChangesAsync();
}