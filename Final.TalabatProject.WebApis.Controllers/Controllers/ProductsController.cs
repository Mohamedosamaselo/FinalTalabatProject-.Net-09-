using FinalTalabatProjectWebApis.Controllers.Base;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Application.Abstraction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.TalabatProject.WebApis.Controllers.Controllers;

public class ProductsController(IServiceManager serviceManager) : BaseApiController
{
    [HttpGet] // GET: api/Products
    [ProducesResponseType(typeof(IEnumerable<ProductToReturnDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
    {
        var products = await serviceManager.productService.GetAllProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id : int}")]  // Get: api/products/id
    public async Task<ActionResult<ProductToReturnDto>> getProductById(int id)
    {
        var product = await serviceManager.productService.GetProductAsync(id);

        if (product is null) // we will handel errors inside Error Module

            return NotFound(new { StatusCode = 400, message = "Product Not Found " });

        return Ok(product);
    }

    [HttpGet("brands")] // Get : /api/Products/Brands
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brands = await serviceManager.productService.GetAllBrandsAsync();
        return Ok(brands);
    }

    [HttpGet("Categories")] // Get : api/Products/Categories
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCatgeories()
    {
        var Categories = await serviceManager.productService.GetAllCategoriesAsync();
        return Ok(Categories);
    }
}