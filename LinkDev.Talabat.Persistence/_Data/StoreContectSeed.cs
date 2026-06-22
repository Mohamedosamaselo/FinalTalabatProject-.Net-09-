using LinkDev.Talabat.Domain.Entities.Products;
using System.Text.Json;

namespace LinkDev.Talabat.Persistence._Data;

public static class StoreContectSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        // Seed Brands
        //if (!context.Brands.Any())
        //{
        //    // 1- READ JSON FILE
        //    var BarndsData = await File.ReadAllTextAsync("../LinkDev.Talabat.Persistence/_Data/SeedData/brands.json");
        //    //2- DESERIALIZE JSON TO OBJECT [change from json to object]
        //    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BarndsData);
        //    // 3- ADD TO DB
        //    if (Brands is not null)
        //    {
        //        context.Brands.AddRange(Brands);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }

    // Seed Categories
    // Seed Products
}