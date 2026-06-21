using LinkDev.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Persistence._Data.Config.Base;

public class BaseEntityConfigrations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseAuditableEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(Entity => Entity.id).ValueGeneratedOnAdd();
        //"Don't expect me to provide a value for Id. The database will generate it when the row is inserted."

        builder.Property(Entity => Entity.CreatedBy).IsRequired();

        builder.Property(Entity => Entity.LastModifiedBy).IsRequired();

        builder.Property(Entity => Entity.Createdon).IsRequired();

        builder.Property(Entity => Entity.LastModifiedOn).IsRequired();
    }
}