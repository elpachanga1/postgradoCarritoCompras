using AutoMapper;
using DataRepository.Repositories;
using Services.Domain.Services;

namespace ShoppingCartBackEnd.Factories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddTransient(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var productRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Product>>();
                return new ProductService(mapper, productRepository);
            });
            return services;
        }

        public static IServiceCollection AddShoppingCartServices(this IServiceCollection services)
        {
            services.AddTransient(serviceProvider =>
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
            services.AddTransient(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var shoppingCartService = serviceProvider.GetRequiredService<ShoppingCartService>();
                var sessionService = serviceProvider.GetRequiredService<SessionService>();
                var userRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.User>>();
                return new UserService(mapper, shoppingCartService, sessionService, userRepository);
            });
            return services;
        }

        public static IServiceCollection AddItemServices(this IServiceCollection services)
        {
            services.AddTransient(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var itemRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Item>>();
                var productService = serviceProvider.GetRequiredService<ProductService>();
                return new ItemService(mapper, itemRepository, productService);
            });
            return services;
        }

        public static IServiceCollection AddSessionServices(this IServiceCollection services)
        {
            services.AddTransient(serviceProvider =>
            {
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var sessionRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Session>>();
                return new SessionService(mapper, sessionRepository);
            });
            return services;
        }
    }
}
