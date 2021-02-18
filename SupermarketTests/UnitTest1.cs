using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;
using System.Collections.Generic;

namespace SupermarketTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Checkout_Without_Money_Return_False()
        {
            // Arrange
            var customer = new Customer("Adam", 10, 0);
            customer.shoppingCart.Add("test");
            customer.shoppingCartValue.Add(2);
            var shopkeeper = new Shopkeeper();
            // Act
            var result = customer.Checkout(shopkeeper);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Add_Product_To_Shopping_Cart_When_Ur_Underaged_Return_False()
        {
            var customer = new Customer("Adam", 10, 20);
            var products = new List<Product>();
            products.Add(new Product() { name = "alkohol", price = 18, age = 10 });

            var result = customer.Buy(products);

            Assert.IsFalse(result);
        }
    }
}
