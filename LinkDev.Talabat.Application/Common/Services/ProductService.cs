using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Abstraction.Specifications;
using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;
using LinkDev.Talabat.Domain.Entities.Products;
using LinkDev.Talabat.Domain.Specifications.product;
using LinkDev.Talabat.Persistence;

namespace LinkDev.Talabat.Application.Common.Services;

public class ProductService(IUnitOfWork _unitOfWork, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductToReturnDto>> GetAllProductsAsync()
    {
        var spec = new ProductWithBrandAndCategorySpecifications();

        var products = _unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);

        var productsToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);

        return productsToReturn;
    }

    public async Task<ProductToReturnDto> GetProductAsync(int id)
    {
        var product = _unitOfWork.GetRepository<Product, int>().GetAsync(id);

        var productToReturn = mapper.Map<ProductToReturnDto>(product);

        return productToReturn;
    }

    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
    {
        var brands = _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

        var brandsToReturn = mapper.Map<IEnumerable<BrandDto>>(brands);

        return brandsToReturn;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = _unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

        var catgeorysToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);

        return catgeorysToReturn;
    }
}