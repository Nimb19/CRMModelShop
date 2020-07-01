using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();
        Random rnd = new Random();
        private bool isWorking;
        private decimal money;
        private int clientCount;

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        //public List<Cart> Carts { get; set; }
        //public List<Check> Cheks { get; set; }
        //public List<Sell> Sells { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = generator.GetSellers(20);
            Customers = generator.GetCustomers(1000);
            Products = generator.GetProducts(100);
            isWorking = true;

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
            Task.Run(() => CreateCarts(rnd.Next(10, 100)));

            foreach (var cash in CashDesks)
            {
                Task.Run(() => UseCashDesks());
            }
        }

        public void Results()
        {
            isWorking = false;
            var clCount = clientCount;
            var allMoney = money;
            var summ = CashDesks.Sum(x => x.ExitCustomers);
        }

        private void UseCashDesks()
        {
            while (isWorking)
            {
                var cashDesc = CashDesks.OrderByDescending(x => x.Count).First();
                if (cashDesc.Count == 0)
                {
                    continue;
                }
                money += cashDesc.Dequeue();
                clientCount++;
            }
        }

        private void CreateCarts(int sleep = 10, int customersCount = 10)
        {
            var customers = generator.GetCustomers(customersCount);
            var carts = new List<Cart>();

            foreach (var customer in customers)
            {
                if (!isWorking)
                {
                    return;
                }
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

            Thread.Sleep(sleep);
        }
    }
}
