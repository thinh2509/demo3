using DemoApi.Models;

namespace DemoApi.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;

        public Product AddProduct(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return product;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        
    }
}
