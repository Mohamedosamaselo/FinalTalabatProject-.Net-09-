using LinkDev.Talabat.Domain.Entities.Products;
using LinkDev.Talabat.Persistence._Data.Config.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Persistence._Data.Config.Products;

public class BrandConfigurations : BaseAuditableEntityConfigrations<ProductBrand, int>
{
    public override void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        base.Configure(builder); // configure the base entity properties

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}