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
    public class ShoppingCartService
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.ShoppingCart> _shoppingCartRepository;

        public ShoppingCartService(IMapper mapper, IRepository<DataRepository.Models.ShoppingCart> shoppingCartRepository)
        {
            _mapper = mapper;
            this._shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            bool result = false;

            Domain.Models.ShoppingCart shoppingCart = await GetShoppingCart(IdUser, false);
            if (shoppingCart == null)
            {
                result = await CreateShoppingCart(IdUser);
                shoppingCart = await GetShoppingCart(IdUser, false);
            }


            return result;
        }


        private async Task<Domain.Models.ShoppingCart> GetShoppingCart(string IdUser, bool IsCompleted)
        {
            Domain.Models.ShoppingCart shoppingCartDomainEntity = null;

            var shoppingCartsDataEntity = await _shoppingCartRepository.GetAllAsync();

            foreach (var dataShoppingCart in shoppingCartsDataEntity)
            {
                if (dataShoppingCart.IdUser == IdUser && dataShoppingCart.IsCompleted == IsCompleted)
                {
                    shoppingCartDomainEntity = _mapper.Map<Domain.Models.ShoppingCart>(dataShoppingCart);
                    break;
                }
            }
            return shoppingCartDomainEntity;
        }

        private async Task<bool> CreateShoppingCart(string IdUser)
        {
            Domain.Models.ShoppingCart shoppingCartDomainEntity = new Domain.Models.ShoppingCart();

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
