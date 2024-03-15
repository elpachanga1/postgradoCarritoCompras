using AutoMapper;

namespace Services.Domain.Services
{
    public class StoreService
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;
        private readonly UserService _userService;
        
        public StoreService(
            IMapper mapper,
            ProductService productService,
            UserService userService,
            ItemService itemService
        ) {
            _mapper = mapper;
            _productService = productService;
            _userService = userService;            
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        public async Task<global::Services.Domain.Models.Product> GetProductById(int Id)
        {
            return await _productService.GetProductById(Id);
        }

        public async Task<bool> AddProduct(string Sku, string Name, string? Description, int AvailableUnits, float UnitPrice, string? Image)
        {
            return await _productService.AddProduct(Sku, Name, Description, AvailableUnits, UnitPrice, Image);
        }

        public async Task<bool> AddProductToShoppingCart(string IdUser, int IdProduct, int Quantity)
        {
            bool result = await _userService.AddProductToShoppingCart(IdUser, IdProduct, Quantity);
            return result;
        }

        public async Task<bool> DeleteProductFromShoppingCart(string IdUser, int IdItem)
        {
            bool result = await _userService.DeleteProductFromShoppingCart(IdUser, IdItem);
            return result;
        }

        public async Task<bool> EmptyShoppingCart(string IdUser)
        {
            bool result = await _userService.EmptyShoppingCart(IdUser);
            return result;
        }

        public async Task<bool> CompleteshoppingCart(string IdUser)
        {
            bool result = await _userService.CompleteShoppingCart(IdUser);
            return result;
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Item>> GetItemsByProductId(int ProductId)
        {
            return await _userService.GetItemsByProductId(ProductId);
        }

        public async Task<IEnumerable<global::Services.Domain.Models.Item>> GetAllItems()
        {
            return await _userService.GetAllItems();            
        }
    }
}
