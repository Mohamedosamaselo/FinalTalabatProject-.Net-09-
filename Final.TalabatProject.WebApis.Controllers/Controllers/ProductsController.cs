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
}