using AutoMapper;
using DataRepository.Repositories;

namespace Services.Domain.Services
{
    public class ShoppingCartService
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.ShoppingCart> _shoppingCartRepository;
        private readonly ItemService _itemService;

        public ShoppingCartService(IMapper mapper, IRepository<DataRepository.Models.ShoppingCart> shoppingCartRepository, ItemService itemService)
        {
            _mapper = mapper;
            this._shoppingCartRepository = shoppingCartRepository;
            this._itemService = itemService;
        }

        public async Task<bool> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            bool result = false;

            Models.ShoppingCart shoppingCart = await GetShoppingCart(IdUser, false);
            if (shoppingCart == null)
            {
                result = await CreateShoppingCart(IdUser);
                shoppingCart = await GetShoppingCart(IdUser, false);
            }
            await _itemService.CreateItem(IdProduct, Quantity);

            return result;
        }

        public async Task<bool> CompleteShoppingCart(string IdUser)
        {
            bool result = false;

            var shoppingCartsDataEntity = await _shoppingCartRepository.GetAllAsync();

            var shoppingCart = shoppingCartsDataEntity.FirstOrDefault(
                dataShoppingCart => dataShoppingCart.IdUser == IdUser && dataShoppingCart.IsCompleted == false
            );

            if (shoppingCart != null)
            {
                shoppingCart.FinishDate = DateTime.UtcNow;
                shoppingCart.UpdatedDate = DateTime.UtcNow;
                shoppingCart.IsCompleted = true;
                var entity = _mapper.Map<DataRepository.Models.ShoppingCart>(shoppingCart);
                _shoppingCartRepository.Update(entity);
                await _shoppingCartRepository.SaveAsync();                
            }

            return result;
        }


        public async Task<bool> DeleteProductFromShoppingCart(string IdUser, int IdItem)
        {
            bool result = false;

            Models.ShoppingCart shoppingCart = await GetShoppingCart(IdUser, false);
            if (shoppingCart != null)
            {
                result = await _itemService.DeleteItem(IdItem);            }
            
            return result;
        }


        public async Task<bool> EmptyShoppingCart(string IdUser)
        {
            bool result = false;

            Models.ShoppingCart shoppingCart = await GetShoppingCart(IdUser, false);
            if (shoppingCart != null)
            {
                result = await _itemService.DeleteItems();
            }

            return result;
        }


        private async Task<Models.ShoppingCart> GetShoppingCart(string IdUser, bool IsCompleted)
        {
            Models.ShoppingCart shoppingCartDomainEntity = null;

            var shoppingCartsDataEntity = await _shoppingCartRepository.GetAllAsync();

            foreach (var dataShoppingCart in shoppingCartsDataEntity)
            {
                if (dataShoppingCart.IdUser == IdUser && dataShoppingCart.IsCompleted == IsCompleted)
                {
                    shoppingCartDomainEntity = _mapper.Map<Models.ShoppingCart>(dataShoppingCart);
                    break;
                }
            }
            return shoppingCartDomainEntity;
        }

        private async Task<bool> CreateShoppingCart(string IdUser)
        {
            Models.ShoppingCart shoppingCartDomainEntity = new Models.ShoppingCart();

            shoppingCartDomainEntity.IdUser = IdUser;
            shoppingCartDomainEntity.CreationDate = DateTime.UtcNow;
            shoppingCartDomainEntity.UpdatedDate = shoppingCartDomainEntity.CreationDate;
            shoppingCartDomainEntity.IsCompleted = false;
            
            DataRepository.Models.ShoppingCart shoppingCartDataEntity = _mapper.Map<DataRepository.Models.ShoppingCart>(shoppingCartDomainEntity);
            await _shoppingCartRepository.AddAsync(shoppingCartDataEntity);
            await _shoppingCartRepository.SaveAsync();            
            
            return true;        
        }    
    }
}
