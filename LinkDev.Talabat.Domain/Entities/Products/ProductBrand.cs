namespace LinkDev.Talabat.Domain.Entities.Products;

public class ProductBrand : BaseAuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
}