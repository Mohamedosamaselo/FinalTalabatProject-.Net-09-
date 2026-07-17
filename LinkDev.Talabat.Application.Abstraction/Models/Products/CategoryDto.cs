namespace LinkDev.Talabat.Application.Abstraction.Models.Products;

public record CategoryDto
{
    public int id { get; set; }
    public required string Name { get; set; }
}