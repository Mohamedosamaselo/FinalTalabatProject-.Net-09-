using LinkDev.Talabat.Application.Abstraction;
using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;
using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LinkDev.Talabat.Persistence.Repositaries.GenericRepositary;

public class GenericRepositary<TEntity, TKey>(StoreContext _dbContext) : IGenericRepository<TEntity, TKey>
                                                                         where TEntity : BaseEntity<TKey>
                                                                         where TKey : IEquatable<TKey>

{
    private readonly StoreContext dbContext = _dbContext;

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
    {
        if (typeof(TEntity) == typeof(Product))
        {
            if (withTracking)
                return await this.dbContext.Set<TEntity>()
                    .Include(p => (p as Product)!.Brand)
                    .Include(p => (p as Product)!.Category).ToListAsync();

            return await this.dbContext.Set<TEntity>()
                .Include(p => (p as Product)!.Brand)
                .Include(p => (p as Product)!.Category).AsNoTracking().ToListAsync();
        }

        return withTracking
            ? await this.dbContext.Set<TEntity>().ToListAsync()
            : await this.dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        //=> await this.dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(TKey id)
    {
        if (typeof(TEntity) == typeof(Product))
            return await dbContext.Set<Product>()
                                  .Where(E => E.Id.Equals(id))
                                  .Include(p => p.Brand)
                                  .Include(p => p.Category)
                                  .FirstOrDefaultAsync() as TEntity;

        return await dbContext.Set<Product>().FindAsync(id) as TEntity;
    }

    public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity, TKey> spec)
        => await ApplySpecifications(spec).ToListAsync();

    public async Task<TEntity?> GetWithSpecAsync(ISpecification<TEntity, TKey> spec)
       => await ApplySpecifications(spec).FirstOrDefaultAsync();

    public async Task AddAsync(TEntity entity)
        => await this.dbContext.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
        => this.dbContext.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity)
        => this.dbContext.Set<TEntity>().Remove(entity);

    public async Task<bool> AnyAsync(TKey id)
        => await this.dbContext.Set<TEntity>().FindAsync(id) is not null;

    public async Task<int> SaveChangesAsync()
        => await this.dbContext.SaveChangesAsync();

    #region Helpers Methods

    private IQueryable<TEntity> ApplySpecifications(ISpecification<TEntity, TKey> spec)
    {
        return SpecificationsEvaluator<TEntity, TKey>.getQuery(_dbContext.Set<TEntity>(), spec);
    }

    #endregion Helpers Methods
}