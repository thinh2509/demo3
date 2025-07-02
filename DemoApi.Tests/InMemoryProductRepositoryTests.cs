using Xunit;
using DemoApi.Models;
using DemoApi.Repositories;
using System.Linq;

namespace DemoApi.Tests
{
    public class InMemoryProductRepositoryTests
    {
        [Fact]
        public void AddProduct_ShouldAssignIdAndAddProductToList()
        {
            // Arrange
            var repository = new InMemoryProductRepository();
            var product = new Product { Name = "Laptop Dell", Price = 10.00m };

            // Act
            var addedProduct = repository.AddProduct(product);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.True(addedProduct.Id > 0);
            Assert.Equal("Laptop Dell", addedProduct.Name);
            Assert.Equal(10.00m, addedProduct.Price);
            Assert.Contains(addedProduct, repository.GetAllProducts());
        }

        [Fact]
        public void GetProductById_ShouldReturnCorrectProduct()
        {
            // Arrange
            var repository = new InMemoryProductRepository();
            var product1 = new Product { Name = "Product 1", Price = 10.00m };
            var product2 = new Product { Name = "Product 2", Price = 20.00m };
            repository.AddProduct(product1);
            repository.AddProduct(product2);

            // Act
            var retrievedProduct = repository.GetProductById(product1.Id);

            // Assert
            Assert.NotNull(retrievedProduct);
            Assert.Equal(product1.Id, retrievedProduct.Id);
            Assert.Equal("Product 1", retrievedProduct.Name);
        }

        [Fact]
        public void GetProductById_ShouldReturnNull_WhenProductNotFound()
        {
            // Arrange
            var repository = new InMemoryProductRepository();

            // Act
            var retrievedProduct = repository.GetProductById(999);

            // Assert
            Assert.Null(retrievedProduct);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var repository = new InMemoryProductRepository();
            repository.AddProduct(new Product { Name = "Product A", Price = 10m });
            repository.AddProduct(new Product { Name = "Product B", Price = 20m });

            // Act
            var products = repository.GetAllProducts().ToList();

            // Assert
            Assert.NotNull(products);
            Assert.Equal(2, products.Count);
            Assert.Contains(products, p => p.Name == "Product A");
            Assert.Contains(products, p => p.Name == "Product B");
        }
    }
}
