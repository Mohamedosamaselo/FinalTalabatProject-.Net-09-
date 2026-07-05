using LinkDev.Talabat.Application.Abstraction;
using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Persistence;

public static class SpecificationsEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
                                                            where TKey : IEquatable<TKey>
{
    public static IQueryable<TEntity> getQuery(IQueryable<TEntity> Dbset, ISpecification<TEntity, TKey> SpecificationObject)
    {
        var Query = Dbset;  // _dbContext.set<TEntity>()

        if (SpecificationObject.Criteria is not null)

            Dbset.Where(SpecificationObject.Criteria); // _dbContext.set<TEntity>(E => E.Id.equals(id))

        /// Includes Expressions
        /// Include(p => p.Brand)
        /// Include(p => p.Category)

        Query = SpecificationObject.Includes.Aggregate(Query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

        ///  _dbContext.set<TEntity>(E => E.Id.equals(id)).Include(P => P.Brand); 1st iteration
        ///  _dbContext.set<TEntity>(E => E.Id.equals(id)).Include(P => P.Brand).Include(P => P,Categories); 2nd Iteration

        return Query.AsQueryable();
    }
}