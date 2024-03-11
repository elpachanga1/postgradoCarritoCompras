using AutoMapper;
using BusinessRules.RulesForPrice.Handlers;
using DataRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class ItemService
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.Item> _itemRepository;
        private readonly ProductService _productService;
        private readonly PriceCalculatorHandler _priceCalculatorHandler;

        public ItemService(IMapper mapper, IRepository<DataRepository.Models.Item> itemRepository, ProductService productService)
        {
            _mapper = mapper;
            this._itemRepository = itemRepository;
            this._productService = productService; 
        }

        public async Task<bool> DeleteItem(int IdItem)
        {
            bool result = false;

            var itemDataEntity = await _itemRepository.FindByIdAsync(IdItem);
            
            if(itemDataEntity != null) 
            { 
                itemDataEntity.IsDeleted = true;
                _itemRepository.Update(itemDataEntity);
                await _itemRepository.SaveAsync();
                result = true;
            }
            return result;
        }

        public async Task<bool> CreateItem(int IdProduct, int Quantity)
        {
            Domain.Models.Item itemDomainEntity = new Domain.Models.Item();
            Domain.Models.Product productDomainEntity = await this._productService.GetProductById(IdProduct);

            itemDomainEntity.IdProduct = IdProduct;
            itemDomainEntity.Quantity = Quantity;
            itemDomainEntity.IsDeleted = false;
            itemDomainEntity.TotalPrice = PriceCalculatorHandler.GetInstance().CalculateItemPrice(productDomainEntity.Sku, Quantity, productDomainEntity.UnitPrice);

            DataRepository.Models.Item shoppingCartDataEntity = _mapper.Map<DataRepository.Models.Item>(itemDomainEntity);
            await _itemRepository.AddAsync(shoppingCartDataEntity);
            await _itemRepository.SaveAsync();

            return true;
        }
    }
}
