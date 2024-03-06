using CarritoComprasBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarritoComprasBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductService _productService;

    public ProductController(
        ProductService service,
        ILogger<ProductController> logger
    ) {
        _logger = logger;
        _productService = service;
    }

    [HttpGet(Name = "GetProducts")]
    public IActionResult Get()
    {
        try {
            var products = _productService.GetAllProducts();
            return Ok(products);
        } catch (Exception ex) {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product with the specified ID doesn't exist
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("sku/{sku}")]
    public IActionResult GetProductBySku(string sku)
    {
        try
        {
            var product = _productService.GetProductBySku(sku);
            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product with the specified ID doesn't exist
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
