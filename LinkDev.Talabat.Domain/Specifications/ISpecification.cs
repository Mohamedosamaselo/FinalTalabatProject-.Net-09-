using System.Linq.Expressions;

namespace LinkDev.Talabat.Application.Abstraction;

// contains property Signature for each and every spec
public interface ISpecification<TEntity, TKey>
                                           where TEntity : BaseEntity<TKey>
                                           where TKey : IEquatable<TKey>
{
    //.Where(E => E.id.Equals(id))
    public Expression<Func<TEntity, bool>> Criteria { get; set; }

    // .Include(p => p.Brand)  .Include(p => p.Categories )
    public List<Expression<Func<TEntity, object>>> Includes { get; set; }
}