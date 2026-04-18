using Xunit;
using NorthwindCatalog.Services.Dtos;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDto
            {
                ProductName = "Test Product",
                UnitPrice = 10.0m,
                UnitsInStock = 5
            };

            var result = product.InventoryValue;

            Assert.Equal(50.0m, result);
        }

        [Theory]
        [InlineData(10.0, 5, 50.0)]     // Standard case
        [InlineData(25.50, 4, 102.0)]   // Decimal price
        [InlineData(0.0, 100, 0.0)]     // Zero price
        [InlineData(50.0, 0, 0.0)]      // Zero stock
        [InlineData(99.99, 10, 999.9)]  // Large value
        public void InventoryValue_Should_Calculate_Correctly_For_Multiple_Inputs(decimal price, short stock, decimal expected)
        {
            var product = new ProductDto
            {
                ProductName = "Batch Test",
                UnitPrice = price,
                UnitsInStock = stock
            };

            var result = product.InventoryValue;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void InventoryValue_Should_Handle_Precision()
        {
            var product = new ProductDto { UnitPrice = 1.33m, UnitsInStock = 3 };
            Assert.Equal(3.99m, product.InventoryValue);
        }
    }
}
