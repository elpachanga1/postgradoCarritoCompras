﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.Services;
using ShoppingCartBackEnd.Entities.Models.InputModels;

namespace CarritoComprasBackend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly StoreService _storeService;

        public StoreController(ILogger<StoreController> logger, StoreService storeFactory)
        {
            this._logger = logger;
            this._storeService = storeFactory;          
        }

        [HttpGet("/Product/GetProductById/{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _storeService.GetProductById(id);
                if (product == null)
                {
                    return NotFound(); 
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("/Product/GetAllProducts", Name = "GetAllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _storeService.GetAllProducts();                
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
                result = await _storeService.AddProduct(productInputModel.Sku, productInputModel.Name, productInputModel.Description, productInputModel.AvailableUnits, productInputModel.UnitPrice, productInputModel.Image);
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


        [HttpGet("/Item/GetItemsByProductId/{ProductId}", Name = "GetItemsByProductId")]
        public async Task<IActionResult> GetItemsByProductId(int ProductId)
        {
            try
            {
                var item = await _storeService.GetItemsByProductId(ProductId);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("/Item/GetAllItems", Name = "GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var items = await _storeService.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("/Store/AddProductToShoppingCart", Name = "AddProductToShoppingCart")]
        public async Task<IActionResult> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            try
            {
                await _storeService.AddProductToShoppingCart(IdUser, IdProduct, Quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("/Store/DeleteProductFromShoppingCart", Name = "DeleteProductFromShoppingCart")]
        public async Task<IActionResult> DeleteProductFromShoppingCartAsync(string IdUser, int IdItem)
        {
            bool result = false;
            try
            {
                result = await _storeService.DeleteProductFromShoppingCart(IdUser, IdItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("/Store/EmptyShoppingCart", Name = "EmptyShoppingCart")]
        public async Task<IActionResult> EmptyShoppingCartAsync(string IdUser)
        {
            bool result = false;
            try
            {
                result = await _storeService.EmptyShoppingCart(IdUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("/Store/CompleteCartTransaction", Name = "CompleteCartTransaction")]
        public async Task<IActionResult> CompleteCartTransaction(string IdUser)
        {
            bool result = false;
            try
            {
                result = await _storeService.CompleteshoppingCart(IdUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("/Store/GetTotalSales", Name = "GetTotalSales")]
        public async Task<IActionResult> GetTotalSales()
        {
            try
            {
                var TotalSales = await _storeService.GetTotalSales();
                return Ok(TotalSales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
