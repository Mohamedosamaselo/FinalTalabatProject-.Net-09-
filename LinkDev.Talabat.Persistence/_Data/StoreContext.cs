using LinkDev.Talabat.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Persistence._Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> Categories { get; set; }
    public virtual DbSet<ProductBrand> Brands { get; set; }
}