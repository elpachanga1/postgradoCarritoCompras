﻿using AutoMapper;
using DataRepository.Repositories;
using Services.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class StoreService
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;
        private readonly UserService _userService;

        public StoreService(IMapper mapper, ProductService productService, UserService userService)
        {
            _mapper = mapper;
            _productService = productService;
            _userService = userService;
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Product>> GetAllProducts()
        {
            return await _productService.GetAllProductsAsync();
        }

        public async Task<global::Services.Domain.Models.Product> GetProductById(int Id)
        {
            return await _productService.GetProductById(Id);
        }

        public async Task<bool> AddProduct(string Sku, string Name, string? Description, int AvailableUnits, float UnitPrice, string? Image)
        {
            return await _productService.CreateProductAsync(Sku, Name, Description, AvailableUnits, UnitPrice, Image);
        }

        public async Task<bool> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            bool result = await _userService.AddProductToShoppingCart(IdUser, IdProduct, Quantity);
            return result;
        }
    }

}