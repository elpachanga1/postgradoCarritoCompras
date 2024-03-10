using CarritoComprasBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartBackEnd.Factories;

namespace CarritoComprasBackend.Controllers
{
    [Route("SC/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly UserFactory _userFactory;

        public StoreController(
            UserFactory userFactory,
            ILogger<ProductController> logger
        )
        {
            _logger = logger;
            _userFactory = userFactory;
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
