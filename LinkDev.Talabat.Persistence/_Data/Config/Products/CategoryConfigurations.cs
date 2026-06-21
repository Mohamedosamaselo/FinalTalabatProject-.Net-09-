using LinkDev.Talabat.Persistence._Data.Config.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Persistence._Data.Config.Products;

public class CategoryConfigurations : BaseEntityConfigrations<ProductCategory, int>
{
    public override void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}