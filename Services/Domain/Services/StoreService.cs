using AutoMapper;
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

        public StoreService(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;            
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
    }
}
