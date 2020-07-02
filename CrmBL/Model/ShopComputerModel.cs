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

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        public int CountCashDescks { get; set; }

        public ShopComputerModel(int countCashDescks = 3)
        {
            CountCashDescks = countCashDescks;
            var sellers = generator.GetSellers(20);
            Customers = generator.GetCustomers(1000);
            Products = generator.GetProducts(100);
            isWorking = true;

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < CountCashDescks; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        /// <summary>
        /// Начинает процесс моделирование.
        /// </summary>
        public void Start()
        {
            isWorking = true;

            Task.Run(() => CreateCarts());

            foreach (var cash in CashDesks)
            {
                Task.Run(() => UseCashDesks(cash));
            }
        }

        /// <summary>
        /// Заканчивает процесс моделирования.
        /// </summary>
        public List<Check> Stop()
        {
            isWorking = false;
            return Checks;
        }

        private void UseCashDesks(CashDesk cashDesk, int sleep = 100)
        {
            while (isWorking)
            {
                if (cashDesk.Count == 0)
                {
                    continue;
                }
                Checks.Add(cashDesk.Dequeue());
                Thread.Sleep(sleep);
            }
        }

        private void CreateCarts(int sleep = 50, int customersCount = 10)
        {
            while (isWorking)
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
                    var currProducts = generator.GetRandomProducts(Products);
                    foreach (var product in currProducts)
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

                Thread.Sleep(sleep);
            }
        }
    }
}
