namespace LinkDev.Talabat.Persistence._Data;

public static class StoreContectSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        // Seed Brands
        if (!context.Brands.Any())
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var BarndsData = await File.ReadAllTextAsync(Path.Combine(currentDirectory, "Persistence/_Data/SeedData/brands.json"));
        }
    })

        // Seed Categories
        // Seed Products
    }
}