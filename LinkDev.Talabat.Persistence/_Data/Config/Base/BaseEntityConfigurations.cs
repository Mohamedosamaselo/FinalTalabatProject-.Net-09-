using LinkDev.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Persistence._Data.Config.Base;

public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(Entity => Entity.Id).ValueGeneratedOnAdd();
        //"Don't expect me to provide a value for Id. The database will generate it when the row is inserted."
    }
}