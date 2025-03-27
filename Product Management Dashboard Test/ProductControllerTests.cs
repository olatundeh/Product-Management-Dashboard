using Microsoft.EntityFrameworkCore;
using Product_Management_Dashboard.Controllers;
using Product_Management_Dashboard.Models;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Management_Dashboard_Test
{
    public class ProductControllerTests
    {
        private static DbContextOptions<ProductDbContext> CreateInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private static void SeedDatabase(ProductDbContext context)
        {
            context.Product.AddRange(
                new Product { Id = 1, ProductName = "Test Product 1", ProductCode = "TP1", Price = 10.0f, Quantity = 5, Category = "Test", CreatedAt = DateTime.Now },
                new Product { Id = 2, ProductName = "Test Product 2", ProductCode = "TP2", Price = 20.0f, Quantity = 10, Category = "Test2", CreatedAt = DateTime.Now.AddDays(-1) }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAllProducts_ReturnsAllProducts()
        {
            var options = CreateInMemoryOptions();
            using var context = new ProductDbContext(options);
            {
                SeedDatabase(context);
                var controller = new ProductController(context);
                var result = await controller.GetAllProducts();

                Assert.NotNull(result);
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task AddProduct_AddsNewProduct()
        {
            var options = CreateInMemoryOptions();
            using var context = new ProductDbContext(options);
            {
                SeedDatabase(context);
                var controller = new ProductController(context);
                var newProduct = new Product { ProductName = "New Product", ProductCode = "NP1", Price = 30.0f, Quantity = 15, Category = "New" };
                var addedProduct = await controller.AddProduct(newProduct);

                Assert.NotNull(addedProduct);
                Assert.Equal("New Product", addedProduct.ProductName);
                Assert.Equal(3, context.Product.Count());
            }
        }

        [Fact]
        public async Task UpdateProduct_UpdatesExistingProduct()
        {
            var options = CreateInMemoryOptions();
            using var context = new ProductDbContext(options);
            {
                SeedDatabase(context);
                var controller = new ProductController(context);
                var updatedProduct = new Product { Id = 1, ProductName = "Updated Product", ProductCode = "UP1", Price = 40.0f, Quantity = 20, Category = "Updated", CreatedAt = DateTime.Now };
                var result = await controller.UpdateProduct(updatedProduct);

                Assert.NotNull(result);
                Assert.Equal("Updated Product", result.ProductName);
                Assert.Equal(40.0f, result.Price);
                Assert.Equal(20, result.Quantity);
                Assert.Equal("Updated", result.Category);
            }
        }

        [Fact]
        public void DeleteProduct_DeletesExistingProduct()
        {
            var options = CreateInMemoryOptions();
            using var context = new ProductDbContext(options);
            {
                SeedDatabase(context);
                var controller = new ProductController(context);
                bool result = controller.DeleteProduct(1);

                Assert.True(result);
                Assert.Equal(1, context.Product.Count());
                Assert.Null(context.Product.Find(1));
            }
        }

        [Fact]
        public void DeleteProduct_ReturnsFalseWhenProductNotFound()
        {
            var options = CreateInMemoryOptions();
            using var context = new ProductDbContext(options);
            {
                SeedDatabase(context);
                var controller = new ProductController(context);
                bool result = controller.DeleteProduct(99);

                Assert.False(result);
                Assert.Equal(2, context.Product.Count());
            }
        }
    }
}