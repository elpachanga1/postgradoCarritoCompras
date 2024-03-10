//namespace CarritoComprasBackend.Services;

//using CarritoComprasBackend.Data;
//using CarritoComprasBackend.Entities.Models;

//public class ProductService
//{
//    private readonly AppDbContext _dbContext;

//    public ProductService(AppDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public List<Product> GetAllProducts()
//    {
//        return _dbContext.Products.ToList();
//    }

//    public Product? GetProductById(int id)
//    {
//        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
//    }

//    public Product? GetProductBySku(string sku)
//    {
//        return _dbContext.Products.FirstOrDefault(p => p.Sku == sku);
//    }
//}