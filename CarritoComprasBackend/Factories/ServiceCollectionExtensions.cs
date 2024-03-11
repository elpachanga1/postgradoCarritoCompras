using AutoMapper;
using BusinessRules.RulesForPrice.Handlers;
using DataRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain.Services;

namespace ShoppingCartBackEnd.Factories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddTransient<ProductService>(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var productRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Product>>();
                return new ProductService(mapper, productRepository);
            });
            return services;
        }

        public static IServiceCollection AddShoppingCartServices(this IServiceCollection services)
        {
            services.AddTransient<ShoppingCartService>(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var shoppingCartRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.ShoppingCart>>();
                var itemService = serviceProvider.GetRequiredService<ItemService>();
                return new ShoppingCartService(mapper, shoppingCartRepository, itemService);
            });
            return services;
        }


        public static IServiceCollection AddStoreServices(this IServiceCollection services)
        {
            services.AddTransient<StoreService>();
            return services;
        }

        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var shoppingCartService = serviceProvider.GetRequiredService<ShoppingCartService>();
                return new UserService(mapper, shoppingCartService);
            });
            return services;
        }

        public static IServiceCollection AddItemServices(this IServiceCollection services)
        {
            services.AddTransient<ItemService>(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var itemRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Item>>();
                var productService = serviceProvider.GetRequiredService<ProductService>();
                return new ItemService(mapper, itemRepository, productService);
            });
            return services;
        }

    }
}
