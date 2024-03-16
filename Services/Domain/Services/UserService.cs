using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingCartService _shoppingCartService;

        public UserService(IMapper mapper, ShoppingCartService shoppingCartService) 
        {
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<bool> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            bool result = await _shoppingCartService.AddProductToShoppingCart(IdUser, IdProduct, Quantity);
            return result;
        }

        public async Task<bool> DeleteProductFromShoppingCart(string IdUser, int IdItem)
        {
            bool result = false;
            result = await _shoppingCartService.DeleteProductFromShoppingCart(IdUser, IdItem);
            return result;
        }

        public async Task<bool> EmptyShoppingCart(string IdUser)
        {
            bool result = false;
            result = await _shoppingCartService.EmptyShoppingCart(IdUser);
            return result;
        }

        public async Task<bool> CompleteShoppingCart(string IdUser)
        {
            bool result = false;
            result = await _shoppingCartService.CompleteShoppingCart(IdUser);
            return result;
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Item>> GetItemsByProductId(int ProductId)
        {
            return await _shoppingCartService.GetItemsByProductId(ProductId);
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Item>> GetAllItems()
        {
            return await _shoppingCartService.GetAllItems();
        }

        public async Task<float> GetTotalSales()
        {
            return await _shoppingCartService.GetTotalSales();
        }
    }
}
