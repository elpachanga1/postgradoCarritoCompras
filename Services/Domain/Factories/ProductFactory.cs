using AutoMapper;
using DataRepository.Models;
using DataRepository.Repositories;
using Services.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Factories
{
    public class ProductFactory
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.Product> _productRepository;

        public ProductFactory(IMapper mapper, IRepository<DataRepository.Models.Product> productRepository)
        {
            _mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<IEnumerable<Services.Domain.Models.Product>> GetAllProductsAsync()
        {
            List<Services.Domain.Models.Product> productsDomainEntity = new List<Services.Domain.Models.Product>();
            
            var productsDataEntity = await _productRepository.GetAllAsync();

            foreach (var dataProduct in productsDataEntity)
            {
                productsDomainEntity.Add(_mapper.Map<Services.Domain.Models.Product>(dataProduct));
            }
            return productsDomainEntity;           
        }

        public async Task<bool> CreateProductAsync(string Sku, string Name, string? Description, int AvailableUnits, float UnitPrice, string? Image)
        {
            Services.Domain.Models.Product productDomainEntity = new Services.Domain.Models.Product
            {
                Sku = Sku, 
                Name = Name, 
                Description = Description,
                AvailableUnits = AvailableUnits,
                UnitPrice = UnitPrice,
                Image = Image
            };

            DataRepository.Models.Product productDataEntity = _mapper.Map<DataRepository.Models.Product>(productDomainEntity);
            await _productRepository.AddAsync(productDataEntity);
            await _productRepository.SaveAsync(); 

            return true;
        }
    }
}
