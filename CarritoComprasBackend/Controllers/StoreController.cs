using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.Factories;
using ShoppingCartBackEnd.Entities.Models.InputModels;

namespace CarritoComprasBackend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductFactory _productFactory;

        public StoreController(ProductFactory productFactory, ILogger<ProductController> logger
           
        )
        {
            this._logger = logger;
            this._productFactory = productFactory;            
        }

        [HttpGet("/Product/GetProducts", Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                //var products = _productFactory.GetAllProductsAsync();
                var products = await _productFactory.GetAllProductsAsync();
                //return Ok(products);                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("/Product/AddProduct", Name = "AddProduct")]
        public async Task<IActionResult> Add([FromBody] ProductInputModel productInputModel)
        {
            try
            {
                bool result = false;
                result = await _productFactory.CreateProductAsync(productInputModel.Sku, productInputModel.Name, productInputModel.Description, productInputModel.AvailableUnits, productInputModel.UnitPrice, productInputModel.Image);
                if (result)
                {
                    return Ok();
                }
                else
                    throw new Exception("Error insertando producto");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("AddProductToShoppingCart", Name = "AddProductToShoppingCart")]
        public IActionResult AddProductToShoppingCart(int idUser, int IdProduct, int Quantity)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("DeleteProductFromShoppingCart", Name = "DeleteProductFromShoppingCart")]
        public IActionResult DeleteProductFromShoppingCart(int idUser, int IdItem)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("CompleteCartTransaction", Name = "CompleteCartTransaction")]
        public IActionResult CompleteCartTransaction(int idUser)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
