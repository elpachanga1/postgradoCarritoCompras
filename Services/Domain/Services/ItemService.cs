using AutoMapper;
using BusinessRules.RulesForPrice.Handlers;
using DataRepository.Repositories;

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
            
            if (itemDataEntity != null) 
            { 
                itemDataEntity.IsDeleted = true;
                _itemRepository.Update(itemDataEntity);
                await _itemRepository.SaveAsync();
                result = true;
            }
            return result;
        }

        // empty shopping cart
        public async Task<bool> DeleteItems()
        {
            bool result = false;

            var itemDataEntity = await _itemRepository.GetAllAsync();
            foreach (var item in itemDataEntity)
            {
                item.IsDeleted = true;
                _itemRepository.Update(item);
                result = true;
            }
            await _itemRepository.SaveAsync();
            return result;
        }

        public async Task<bool> CreateItem(int IdProduct, int Quantity)
        {
            var currentItem = (await _itemRepository.GetAllAsync()).FirstOrDefault(x => x.IdProduct == IdProduct);
            Models.Product? productDomainEntity = await _productService.GetProductById(IdProduct);

            if (currentItem == null)
            {
                Models.Item itemDomainEntity = new Models.Item();

                itemDomainEntity.IdProduct = IdProduct;
                itemDomainEntity.Quantity = Quantity;
                itemDomainEntity.IsDeleted = false;
                itemDomainEntity.TotalPrice = PriceCalculatorHandler.GetInstance().CalculateItemPrice(
                    productDomainEntity.Sku,
                    Quantity,
                    productDomainEntity.UnitPrice);

                DataRepository.Models.Item shoppingCartDataEntity = _mapper.Map<DataRepository.Models.Item>(itemDomainEntity);
                await _itemRepository.AddAsync(shoppingCartDataEntity);
            }
            else
            {
                if (currentItem.IsDeleted)
                {
                    currentItem.IsDeleted = false;
                    currentItem.Quantity = Quantity;
                }
                else
                {
                    currentItem.Quantity += Quantity;
                }
                currentItem.TotalPrice = PriceCalculatorHandler.GetInstance().CalculateItemPrice(
                    productDomainEntity.Sku,
                    currentItem.Quantity,
                    productDomainEntity.UnitPrice);
                _itemRepository.Update(currentItem);
            }
            
            await _itemRepository.SaveAsync();

            return true;
        }

        public async Task<List<Models.Item>> GetItemsByProductId(int ProductId)
        {
            List<Models.Item> itemDomainEntity = new List<Models.Item>();

            var itemDataEntity = await _itemRepository.GetAllAsync();
            var items = itemDataEntity.Where(item => item.IdProduct == ProductId);

            foreach (var dataProduct in items)
            {
                itemDomainEntity.Add(_mapper.Map<Models.Item>(dataProduct));
            }
            return itemDomainEntity;
        }

        public async Task<List<Models.Item>> GetAllItems()
        {
            List<Models.Item> itemDomainEntity = new List<Models.Item>();

            var itemDataEntity = await _itemRepository.GetAllAsync();
            var items = itemDataEntity.Where(item => !item.IsDeleted);

            if (items != null)
            {
                foreach (var dataProduct in items)
                {
                    itemDomainEntity.Add(_mapper.Map<Models.Item>(dataProduct));
                }
            }
            
            return itemDomainEntity;
        }
    }
}
