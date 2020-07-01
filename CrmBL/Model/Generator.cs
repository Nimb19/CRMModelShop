using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Generator
    {
        private Random rnd = new Random();

        /// <summary>
        /// Количество покупателей для ведения id.
        /// </summary>
        private int _customers { get; set; }

        /// <summary>
        /// Генерировать клиентов.
        /// </summary>
        /// <param name="count"> Количество клиентов. </param>
        /// <returns></returns>
        public List<Customer> GetCustomers(int count = 5)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                Customer customer = new Customer()
                {
                    CustomerId = _customers,
                    Name = GetRandomText()
                };
                customers.Add(customer);
            }

            return customers;
        }

        /// <summary>
        /// Количество продуктов для ведения id.
        /// </summary>
        private int _products { get; set; }

        /// <summary>
        /// Генерировать продукты.
        /// </summary>
        /// <param name="count"> Количество продуктов. </param>
        /// <returns></returns>
        public List<Product> GetProducts(int count = 5)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                Product product = new Product()
                {
                    ProductId = _products,
                    Name = GetRandomText(),
                    Price = rnd.Next(25, 500),
                    Count = rnd.Next(50, 150)
                };
                products.Add(product);
                _products++;
            }

            return products;
        }

        /// <summary>
        /// Количество продавцов для ведения id.
        /// </summary>
        private int _sellers { get; set; }

        /// <summary>
        /// Генерировать продавцов.
        /// </summary>
        /// <param name="count"> Количество продавцов. </param>
        /// <returns></returns>
        public List<Seller> GetSellers(int count = 5)
        {
            List<Seller> sellers = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                Seller seller = new Seller()
                {
                    SellerId = _sellers,
                    Name = GetRandomText()
                };
                sellers.Add(seller);
            }

            return sellers;
        }

        /// <summary>
        /// Случайные продукты из списка.
        /// </summary>
        /// <param name="products"> Список продуктов. </param>
        /// <param name="min"> Минимальное кол-во продуктов в результате. </param>
        /// <param name="max"> Максимальное кол-во продуктов в результате. </param>
        /// <returns></returns>
        public List<Product> GetRandomProducts(List<Product> products, int min = 1, int max = 25)
        {
            var result = new List<Product>();
            int count = rnd.Next(min, max);

            for (int i = 0; i < count && i < products.Count; i++)
            {
                result.Add(products[rnd.Next(products.Count - 1)]);
            }

            return result;
        }

        /// <summary>
        /// Генератор случайного текста.
        /// </summary>
        /// <param name="length"> Длина текста. </param>
        /// <returns></returns>
        public string GetRandomText(int length = 10)
        {
            return Guid.NewGuid().ToString().Substring(0, length);
        }
    }
}
