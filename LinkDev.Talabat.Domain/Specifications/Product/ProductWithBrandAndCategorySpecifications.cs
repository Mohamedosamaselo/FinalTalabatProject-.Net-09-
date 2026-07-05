using LinkDev.Talabat.Application.Abstraction.Specifications;
using LinkDev.Talabat.Domain.Entities.Products;

namespace LinkDev.Talabat.Domain.Specifications.product;

public class ProductWithBrandAndCategorySpecifications : BaseSpecification<Product, int>
{
    // this object that created via this ctor is used for Building the Query that will get AllProducts
    public ProductWithBrandAndCategorySpecifications() : base()
    {
        Includes.Add(p => p.Brand!);
        Includes.Add(p => p.Category!);
    }
}