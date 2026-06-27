namespace LinkDev.Talabat.Application.Abstraction.Models.Products;

public record ProductToReturnDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Desciption { get; init; } = string.Empty;

    public string PictureUrl { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public int? CategoryId { get; init; }

    public string? Category { get; init; }

    public int? BrandId { get; init; }

    public string? Brand { get; init; }
}