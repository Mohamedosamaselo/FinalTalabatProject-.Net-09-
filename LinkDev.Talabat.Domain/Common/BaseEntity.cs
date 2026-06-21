namespace LinkDev.Talabat.Domain.Common;

public abstract class BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey id { get; set; }
}