using ARAINVARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Infrastructure.Wrappers;
using ARAINV.Infrastructure.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using ARAINV.Core.Custom;

namespace ARAINV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var _products = new ApiResponse<IEnumerable<ProductDTO>>(await _productService.GetProducts());
                return Ok(_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductsPaged")]
        public async Task<IActionResult> GetProductsPaged(FilterProductDTO product)
        {
            try
            {
                var _products = new ApiResponse<MetaData<ProductDTO>>(
                                            await _productService.GetPagedProductAsync(
                                                            product.pageNumber,
                                                            product.pageSize,
                                                            product,
                                                            product.orderBy));
                return Ok(_products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            try
            {
                var _product = await _productService.FindProductAsync(id);
                return Ok(_product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDTO product)
        {
            var response = new ApiResponse<CreateProductDTO>(await _productService.InsertAsync(product), $"El producto '{product.NameProduct}', fue creado correctamente.");

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDTO product)
        {
            try
            {
                var response = new ApiResponse<UpdateProductDTO>(await _productService.UpdateProduct(product), $"El producto de Id '{product.Id}', fue modificado correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductDTO product)
        {
            try
            {
                var _product = await _productService.DeleteProduct(product);
                var response = new ApiResponse<DeleteProductDTO>(_product, $"El producto de id '{_product.Id}' fue eliminado correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
