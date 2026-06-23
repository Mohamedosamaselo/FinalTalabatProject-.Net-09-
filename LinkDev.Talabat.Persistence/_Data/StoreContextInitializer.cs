using LinkDev.Talabat.Domain.Contracts;
using LinkDev.Talabat.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace LinkDev.Talabat.Persistence._Data;

public class StoreContextInitializer(StoreContext _dbContext, ILoggerFactory loggerFactory) : IStoreContextInitilazer
{
    public async Task InitilizeAsync()
    {
        // Update ALl Pending Migrations

        var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any()) await _dbContext.Database.MigrateAsync();
    }

    public async Task SeedAsync()
    {
        var logger = loggerFactory.CreateLogger(nameof(StoreContextSeed));

        try
        {
            // Seed Brands
            if (!_dbContext.Brands.Any())
            {
                var filePath = Path.GetFullPath(
                                    Path.Combine(Directory.GetCurrentDirectory(),
                                            "..",
                                            "LinkDev.Talabat.Persistence",
                                            "_Data",
                                            "DataSeeding",
                                            "brands.json"));

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(
                        $"Brands seed file was not found: {filePath}");
                }
                // 1- READ JSON FILE
                var BarndsData = await File.ReadAllTextAsync(filePath);
                //2- DESERIALIZE JSON TO OBJECT [change from json to object]
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BarndsData);
                // 3- ADD TO DB
                if (brands is not null && brands.Any())
                {
                    await _dbContext.Brands.AddRangeAsync(brands);

                    await _dbContext.SaveChangesAsync();
                }
            }

            // Seed Categories
            if (!_dbContext.Categories.Any())

            {
                var filePath = Path.GetFullPath(
                                    Path.Combine(Directory.GetCurrentDirectory(),
                                            "..",
                                            "LinkDev.Talabat.Persistence",
                                            "_Data",
                                            "DataSeeding",
                                            "categories.json"));

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(
                        $"categories seed file was not found: {filePath}");
                }

                // 1- READ JSON FILE
                var categoriesData = await File.ReadAllTextAsync(filePath);
                //2- DESERIALIZE JSON TO OBJECT [change from json to object]
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                // 3- ADD TO DB
                if (categories is not null && categories.Any())
                {
                    await _dbContext.Categories.AddRangeAsync(categories);

                    await _dbContext.SaveChangesAsync();
                }
            }

            // Seed Products
            if (!_dbContext.Products.Any())
            {
                // get Path of JSON file
                var filePath = Path.GetFullPath(
                                    Path.Combine(Directory.GetCurrentDirectory(),
                                            "..",
                                            "LinkDev.Talabat.Persistence",
                                            "_Data",
                                            "DataSeeding",
                                            "products.json"));

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(
                        $"Products seed file was not found: {filePath}");
                }
                // 1- READ JSON FILE
                var productsData = await File.ReadAllTextAsync(filePath);

                //2- DESERIALIZE JSON TO OBJECT [change from json to object]
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3- ADD TO DB

                if (products?.Count > 0)
                {
                    _dbContext.Products.AddRange(products);
                    await _dbContext.SaveChangesAsync();
                }
            }

            logger.LogInformation("Database seeding completed successfully. ");
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex,
                "Database update error occurred during seeding.");

            logger.LogError(
                "Inner Exception: {Message}",
                ex.InnerException?.Message);

            throw;
        }
    }
}