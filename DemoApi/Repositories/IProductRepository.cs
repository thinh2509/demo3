using DemoApi.Models;

namespace DemoApi.Repositories
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        Product? GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        
    }
}
