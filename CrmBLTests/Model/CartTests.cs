using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "testuser"};
            Product product1 = new Product()
            {
                ProductId = 1,
                Name = "Молоко",
                Price = 100,
                Count = 20
            };
            Product product2 = new Product()
            {
                ProductId = 2,
                Name = "Кукуруза",
                Price = 100,
                Count = 30
            };

            var cart = new Cart(customer);

            List<Product> expectedResult = new List<Product>()
            {
                product1, product1, product1, product1, product2
            };

            // Act
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product1);
            cart.Add(product1, 2);
            var cartToList = cart.ToList();

            // Assert
            Assert.AreEqual(expectedResult.Count, cart.Count);
            for (int i = 0; i < cart.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartToList[i]);
            }
        }
    }
}