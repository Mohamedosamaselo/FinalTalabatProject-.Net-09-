using LinkDev.Talabat.Application.Abstraction.Specifications;
using LinkDev.Talabat.Domain.Entities.Products;

namespace LinkDev.Talabat.Domain.Specifications.product;

public class ProductWithBrandAndCategorySpecifications : BaseSpecification<Product, int>
{
    // this object that created via this ctor is used for Building the Query that will get AllProducts
    public ProductWithBrandAndCategorySpecifications() : base()
    {
        AddIncludes();
    }

    // this object that created via this ctor is used for Building the Query that will getProduct By ID
    public ProductWithBrandAndCategorySpecifications(int id) : base(id)
    {
        AddIncludes();
    }

    private void AddIncludes()
    {
        Includes.Add(p => p.Brand!);
        Includes.Add(p => p.Category!);
    }
}