using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Cart : IEnumerable
    {
        public Customer Customer { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public int Count { get; private set; }

        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public void Add(Product product, uint count = 1)
        {
            if (count == 0)
            {
                return;
            }

            if (Products.ContainsKey(product))
            {
                Products[product] += Convert.ToInt32(count);
            }
            else
            {
                Products.Add(product, Convert.ToInt32(count));
            }

            Count += Convert.ToInt32(count);
        }

        public List<Product> ToList()
        {
            List<Product> result = new List<Product>();
            
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }
    }
}
