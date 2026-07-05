using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;
using LinkDev.Talabat.Persistence._Data;
using LinkDev.Talabat.Persistence.Repositaries;
using LinkDev.Talabat.Persistence.Repositaries.GenericRepositary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreContext dbContext;
    private readonly ConcurrentDictionary<string, object> _repositiries;

    public UnitOfWork(StoreContext _dbContext)
    {
        dbContext = _dbContext;

        _repositiries = new ConcurrentDictionary<string, object>();
        // Note that Concurrent Dictionary is thread Safe that Recommende to be used when we use Async Programming
    }

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
      where TEntity : BaseEntity<TKey>
      where TKey : IEquatable<TKey>
    {
        ///   var TypeName = typeof(TEntity).Name;
        ///
        ///   if (_repositiries.ContainsKey(TypeName))
        ///       return (IGenericRepository<TEntity, TKey>)_repositiries[TypeName];
        ///
        ///   var repo = new GenericRepositary<TEntity, TKey>(dbContext);// create Repo

        return (IGenericRepository<TEntity, TKey>)
              _repositiries.GetOrAdd(typeof(TEntity).Name, new GenericRepositary<TEntity, TKey>(dbContext));// Add Repos to Distionary [save Repo inside it ]
    }

    public async Task<int> CompleteAsync() => await dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
}