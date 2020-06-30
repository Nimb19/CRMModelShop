using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // Arrange
            Customer customer = new Customer() { Name = "Игорь", CustomerId = 0 };
            Customer customer2 = new Customer() { Name = "Чел", CustomerId = 1 };
            Seller seller = new Seller();
            int number = 0;
            CashDesk cashDesk = new CashDesk(number, seller);

            Product product1 = new Product()
            {
                ProductId = 0,
                Name = "Клубника",
                Price = 100,
                Count = 50
            };
            Product product2 = new Product()
            {
                ProductId = 1,
                Name = "Мороженное",
                Price = 75,
                Count = 50
            };
            Cart cart1 = new Cart(customer);
            cart1.Add(product2);
            cart1.Add(product1, 5);
            Cart cart2 = new Cart(customer2);
            cart2.Add(product2);
            cart2.Add(product1);
            cart2.Add(product1);

            // Act
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);
            var resSumm1 = cashDesk.Dequeue();
            var resSumm2 = cashDesk.Dequeue();

            // Assert
            Assert.AreEqual(575, resSumm1);
            Assert.AreEqual(275, resSumm2);
            Assert.AreEqual(43, product1.Count);
            Assert.AreEqual(48, product2.Count);
            Assert.AreEqual(0, cashDesk.Carts.Count);
        }
    }
}