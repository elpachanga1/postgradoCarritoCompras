﻿using AutoMapper;
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
    }
}