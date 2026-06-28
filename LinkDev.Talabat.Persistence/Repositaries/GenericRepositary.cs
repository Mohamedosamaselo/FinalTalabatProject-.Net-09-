using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts;
using LinkDev.Talabat.Persistence._Data;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Persistence.Repositaries;

public class GenericRepositary<TEntity, TKey>(StoreContext _dbContext) : IGenericRepository<TEntity, TKey>
                                                                                    where TEntity : BaseEntity<TKey>
                                                                                    where TKey : IEquatable<TKey>

{
    private readonly StoreContext dbContext = _dbContext;

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(bool withTracking = false)
    {
        if (typeof(TEntity) == typeof(Product))
        {
            if (withTracking)
                return await this.dbContext.Set<TEntity>().Include(p => (p as Product)!.Brand).Include(p => (p as Product)!.Category).ToListAsync();
            else
                return await this.dbContext.Set<TEntity>().Include(p => (p as Product)!.Brand).Include(p => (p as Product)!.Category).AsNoTracking().ToListAsync();
        }
        else
            return withTracking
                ? await this.dbContext.Set<TEntity>().ToListAsync()
                : await this.dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        //=> await this.dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
        => await this.dbContext.Set<TEntity>().FindAsync(id);

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
}