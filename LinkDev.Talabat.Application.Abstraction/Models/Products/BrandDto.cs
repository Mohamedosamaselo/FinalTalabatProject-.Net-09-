namespace LinkDev.Talabat.Application.Abstraction.Models.Products;

public record BrandDto
{
    public int id { get; set; }
    public required string Name { get; set; }
}