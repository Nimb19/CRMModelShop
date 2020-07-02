using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    /// <summary>
    /// Касса.
    /// </summary>
    public class CashDesk
    {
        CRMContext db;

        /// <summary>
        /// Номер кассы.
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Продавец.
        /// </summary>
        public Seller Seller { get; set; }
        
        /// <summary>
        /// Очередь покупателей.
        /// </summary>
        public Queue<Cart> Carts { get; set; }
        
        /// <summary>
        /// Максимальное количество покупателей.
        /// </summary>
        public int MaxQueueCount { get; set; }
        
        /// <summary>
        /// Ушедшие покупатели из-за нехватки мест на кассе.
        /// </summary>
        public int ExitCustomers { get; set; }

        /// <summary>
        /// Общая прибыль с кассы.
        /// </summary>
        public decimal CountProfit { get; set; }
        
        /// <summary>
        /// Создана ли касса в целях моделирования.
        /// </summary>
        public bool IsModel { get; set; }

        /// <summary>
        /// Количество корзин на кассе.
        /// </summary>
        public int Count => Carts.Count;

        /// <summary>
        /// Общее количество покупателей.
        /// </summary>
        public int CountCustomers { get; set; }

        /// <summary>
        /// Срабатывает когда произошла покупка.
        /// </summary>
        public event EventHandler<Check> CheckClosed;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="number"> Номер кассы. </param>
        /// <param name="seller"> Продавец. </param>
        /// <param name="maxQueueCount"> Максимальное количество покупателей. </param>
        /// <param name="isModel"> Создана ли касса в целях моделирования. </param>
        public CashDesk(int number, Seller seller, CRMContext db, int maxQueueCount = 10, bool isModel = true)
        {
            Number = number;
            Seller = seller;
            this.db = db;
            MaxQueueCount = maxQueueCount;
            IsModel = isModel;
            Carts = new Queue<Cart>();
        }

        /// <summary>
        /// Производит покупку.
        /// </summary>
        /// <returns> Итоговая цена. </returns>
        public Check Dequeue()
        {
            if (Carts.Count != 0)
            {
                var currCart = Carts.Dequeue();
                Check check = new Check()
                {
                    Customer = currCart.Customer,
                    CustomerId = currCart.Customer.CustomerId,
                    Seller = Seller,
                    SellerId = Seller.SellerId,
                    DataCreated = DateTime.Now
                };

                List<Sell> sells = new List<Sell>();
                foreach (Product product in currCart)
                {
                    if (product.Count == 0)
                        break;

                    var sell = new Sell()
                    {
                        Check = check,
                        CheckId = check.CheckId,
                        Product = product,
                        ProductId = product.ProductId
                    };
                    sells.Add(sell);

                    if (!IsModel)
                    {
                        db.Sells.Add(sell);
                    }
                    CountProfit += product.Price;
                    product.Count--;
                }

                check.Sells = sells;

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                CheckClosed?.Invoke(this, check);

                return check;
            }

            return null;
        }

        /// <summary>
        /// Добавляет корзину.
        /// </summary>
        /// <param name="cart"> Корзина. </param>
        public void Enqueue(Cart cart)
        {
            if (Carts.Count < MaxQueueCount)
            {
                Carts.Enqueue(cart);
                CountCustomers += 1;
            }
            else
            {
                ExitCustomers++;
            }
        }
    }
}
