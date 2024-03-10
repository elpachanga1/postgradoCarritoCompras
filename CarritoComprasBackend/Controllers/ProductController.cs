using Microsoft.AspNetCore.Mvc;
using DataRepository.Repositories;
using DataRepository.Models;
using CarritoComprasBackend.Entities.Constants;
using System.Drawing;
using ShoppingCartBackEnd.Entities.Models.InputModels;
using Services.Domain.Factories;

namespace CarritoComprasBackend.Controllers;

[ApiController]
[Route("SC/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductFactory _productFactory;
    

    public ProductController(ProductFactory productFactory, IRepository<Product> productRepository, ILogger<ProductController> logger) 
    {
        _logger = logger;
        this._productFactory = productFactory;
        //this._productRepository = productRepository;
    }


   

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            /*var product = this._productRepository.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product with the specified ID doesn't exist
            }
            return Ok(product);*/

            return Ok();
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
            /*var product = _productService.GetProductBySku(sku);
            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product with the specified ID doesn't exist
            }
            return Ok(product);*/
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
