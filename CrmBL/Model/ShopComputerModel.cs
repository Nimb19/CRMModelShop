using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();

        public List<CashDesk> CashDesks { get; set; }
        //public List<Cart> Carts { get; set; }
        //public List<Check> Cheks { get; set; }
        //public List<Sell> Sells { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public Queue<Seller> Sellers { get; set; }

        public ShopComputerModel()
        {
            var sellers = generator.GetSellers(20);
            Customers = generator.GetCustomers(1000);
            Products = generator.GetProducts(100);
            Sellers = new Queue<Seller>();
            CashDesks = new List<CashDesk>();

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = generator.GetCustomers(10);
            var carts = new List<Cart>();

            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var product in generator.GetRandomProducts(Products))
                {
                    cart.Add(product);
                }
                carts.Add(cart);
            }

            foreach (var cart in carts)
            {
                var cashDesc = CashDesks.OrderBy(x => x.Count).First();
                cashDesc.Enqueue(cart);
            }
            carts = new List<Cart>();

            while (true)
            {
                var cashDesc = CashDesks.OrderByDescending(x => x.Count).First();
                if (cashDesc.Count == 0)
                {
                    break;
                }
                cashDesc.Dequeue();
            }
        }
    }
}
