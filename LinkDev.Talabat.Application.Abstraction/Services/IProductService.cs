using LinkDev.Talabat.Application.Abstraction.Models.Products;

namespace LinkDev.Talabat.Application.Abstraction.Services;

public interface IProductService
{
     Task<IEnumerable<ProductToReturnDto>> GetAllProductsAsync();

    Task<ProductToReturnDto> GetProductAsync(int id);

    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
}