using Microsoft.AspNetCore.Mvc;
using Products.Domain.IService;
using Products.Infrastructure;
using Products.Infrastructure.Service;
using Products.Domain.Model.Product;

namespace Products.Facade.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var response = _productService.GetAll().Result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct(int TenantId, int ProductId)
        {
            try
            {
                var response = _productService.Get(TenantId, ProductId).Result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var response = await _productService.Create(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                var response = await _productService.Update(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }

        [HttpDelete]
        [Route("CreateProduct")]
        public async Task<IActionResult> DeleteProduct(int TenantId, int ProductId)
        {
            try
            {
                var response = await _productService.Delete(TenantId, ProductId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.ToString());
            }
        }
    }
}