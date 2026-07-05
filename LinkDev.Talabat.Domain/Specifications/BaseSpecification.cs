using System.Linq.Expressions;

namespace LinkDev.Talabat.Application.Abstraction.Specifications;

// Contain Common Specs of Specifications
public abstract class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey>
                                                         where TEntity : BaseEntity<TKey>
                                                         where TKey : IEquatable<TKey>
{
    //.Where(E => E.id.Equals(id))

    #region Properties

    public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
    public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();

    #endregion Properties

    #region Constructors

    //this ctor will be used in the baseSpecification object that will help in building Query GetAll Entities
    public BaseSpecification()
    {
        //Criteria = null;
        //Includes = new List<Expression<Func<TEntity, object>>>();
    }

    //this ctor will be used in the baseSpecification object that will help in building Query GetByID Entities
    public BaseSpecification(TKey id)
    {
        Criteria = E => E.Id.Equals(id);
        //Includes = new List<Expression<Func<TEntity, object>>>();
    }

    #endregion Constructors
}