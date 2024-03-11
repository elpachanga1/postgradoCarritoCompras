using AutoMapper;
using DataRepository.Models;
using DataRepository.Repositories;
using Services.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.Product> _productRepository;

        public ProductService(IMapper mapper, IRepository<DataRepository.Models.Product> productRepository)
        {
            _mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<Domain.Models.Product> GetProductById(int Id)
        {
            Domain.Models.Product productDomainEntity = null;

            var productDataEntity = await _productRepository.FindByIdAsync(Id);
            if (productDataEntity != null)
            {
                productDomainEntity = _mapper.Map<Domain.Models.Product>(productDataEntity);
            }          
            return productDomainEntity;
        }

        public async Task<IEnumerable<Domain.Models.Product>> GetAllProducts()
        {
            List<Models.Product> productsDomainEntity = new List<Models.Product>();
            
            var productsDataEntity = await _productRepository.GetAllAsync();

            foreach (var dataProduct in productsDataEntity)
            {
                productsDomainEntity.Add(_mapper.Map<Domain.Models.Product>(dataProduct));
            }
            return productsDomainEntity;           
        }

        public async Task<bool> AddProduct(string Sku, string Name, string? Description, int AvailableUnits, float UnitPrice, string? Image)
        {
            Domain.Models.Product productDomainEntity = new Domain.Models.Product
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
