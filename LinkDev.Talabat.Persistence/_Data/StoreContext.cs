using LinkDev.Talabat.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Persistence._Data;

public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> Categories { get; set; }
    public virtual DbSet<ProductBrand> Brands { get; set; }
}