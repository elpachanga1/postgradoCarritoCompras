using CarritoComprasBackend.Services;
using Microsoft.AspNetCore.Mvc;
using DataRepository.Repositories;
using DataRepository.Models;
using ShoppingCartBackEnd.Factories;
using Microsoft.EntityFrameworkCore;

namespace CarritoComprasBackend.Controllers;

[ApiController]
[Route("SC/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductFactory _productFactory;
    private readonly IRepository<Product> _productRepository;    

    public ProductController(ProductFactory productFactory, IRepository<Product> productRepository, ILogger<ProductController> logger) 
    {
        _logger = logger;
        this._productFactory = productFactory;
        this._productRepository = productRepository;
    }

    [HttpPost("AddProduct", Name = "AddProduct")]
    public IActionResult Add([FromBody] Product product)
    {
        try
        {               
            Product productEntity = new Product {
                Sku = product.Sku, 
                Name = product.Name, 
                Description = product.Description,
                AvailableUnits = product.AvailableUnits,
                UnitPrice = product.UnitPrice,
                Image = product.Image
            };
            _productRepository.AddAsync(productEntity);
            _productRepository.SaveAsync();
         
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }


    [HttpGet(Name = "GetProducts")]
    public IActionResult Get()
    {
        try {
            //var products = _productService.GetAllProducts();
            //return Ok(products);
            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            var product = this._productRepository.FindByIdAsync(id);
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
