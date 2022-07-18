using BlazorShopOnline.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductRepository _productRepository { get; }
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetCategories();

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                // Merge products & categories using extension method
                else
                {
                    // call extension method "ConvertToDto"
                    var productDtos = products.ConvertToDto(productCategories);

                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    "Error receiving data from Database");
            }
        }
    }
}
