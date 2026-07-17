namespace LinkDev.Talabat.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public string CreatedBy { get; set; } = string.Empty;

    public DateTime Createdon { get; set; } = DateTime.UtcNow;

    public string LastModifiedBy { get; set; } = string.Empty;

    public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;
}