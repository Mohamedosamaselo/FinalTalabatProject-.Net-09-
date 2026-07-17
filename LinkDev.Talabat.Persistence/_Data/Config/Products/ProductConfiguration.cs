using LinkDev.Talabat.Persistence._Data.Config.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Persistence._Data.Config.Products;

public class ProductConfiguration : BaseAuditableEntityConfigrations<Product, int>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.Property(product => product.Name).IsRequired().HasMaxLength(100);

        builder.Property(product => product.Desciption).IsRequired().HasMaxLength(180);

        builder.Property(product => product.PictureUrl).IsRequired();

        builder.Property(product => product.Price).IsRequired().HasPrecision(18, 2);

        // Relationships
        builder.HasOne(product => product.Category)
            .WithMany()
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(product => product.Brand)
            .WithMany()
            .HasForeignKey(product => product.BrandId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}