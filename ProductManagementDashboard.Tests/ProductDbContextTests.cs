using Microsoft.EntityFrameworkCore;
using Product_Management_Dashboard.Models;
using Xunit;

namespace ProductManagementDashboard.Tests
{
    public class ProductDbContextTests
    {
        private DbContextOptions<ProductDbContext> GetInMemoryDbContextOptions()
        {
            return new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void CanAddProductToDatabase()
        {
            // Arrange
            var options = GetInMemoryDbContextOptions();
            using var context = new ProductDbContext(options);
            var product = new Product
            {
                ProductName = "Test Product",
                ProductCode = "TP001",
                Price = 10.0f,
                Quantity = 100,
                Category = "Test Category",
                CreatedAt = DateTime.Now
            };

            // Act
            context.Products.Equals(product);
            context.SaveChanges();

            // Assert
            Assert.Equal(1, context.Products.GetType().GetProperties().Length);
            Assert.Equal("Test Product", context.Products.ToString());
        }
    }
}
