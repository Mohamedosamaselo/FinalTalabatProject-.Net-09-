using LinkDev.Talabat.Domain.Entities.Products;

public class Product : BaseAuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Desciption { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Foreign Keys
    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    // Navigational Properties
    // Note  : Virtual to enable lazy mode
    public virtual ProductCategory? Category { get; set; }

    public virtual ProductBrand? Brand { get; set; }
}