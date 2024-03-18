using CarritoComprasBackend.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.Services;

namespace ShoppingCartBackEnd.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly StoreService _storeService;

        public AuthController(ILogger<StoreController> logger, StoreService storeFactory)
        {
            this._logger = logger;
            this._storeService = storeFactory;
        }

        [HttpPost("/User/AuthenticateUser", Name = "AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(string username, string password)
        {
            try
            {
                var result = await _storeService.AuthenticateUser(username, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
