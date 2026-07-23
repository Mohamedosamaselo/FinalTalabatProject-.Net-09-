using LinkDev.Talabat.Domain.Entities.Products;
using System.Text.Json;

namespace LinkDev.Talabat.Persistence._Data;

public static class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        // Seed Brands
        if (!context.Brands.Any())
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var brandsData = await File.ReadAllTextAsync(
                Path.Combine(currentDirectory, "Persistence/_Data/SeedData/brands.json"));

            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            if (brands is not null)
            {
                await context.Brands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
        }

        // Seed Categories

        // Seed Products
    }
}