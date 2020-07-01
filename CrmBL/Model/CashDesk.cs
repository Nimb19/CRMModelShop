using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    /// <summary>
    /// Касса.
    /// </summary>
    public class CashDesk
    {
        CRMContext db = new CRMContext();

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
        /// Создана ли касса в целях моделирования.
        /// </summary>
        public bool IsModel { get; set; }

        public int Count => Carts.Count;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="number"> Номер кассы. </param>
        /// <param name="seller"> Продавец. </param>
        /// <param name="maxQueueCount"> Максимальное количество покупателей. </param>
        /// <param name="isModel"> Создана ли касса в целях моделирования. </param>
        public CashDesk(int number, Seller seller, int maxQueueCount = 10, bool isModel = true)
        {
            Number = number;
            Seller = seller;
            MaxQueueCount = maxQueueCount;
            IsModel = isModel;
            Carts = new Queue<Cart>();
        }

        /// <summary>
        /// Произвести покупку.
        /// </summary>
        /// <returns> Итоговая цена. </returns>
        public decimal Dequeue()
        {
            decimal summ = 0;
            var currCart = Carts.Dequeue();
            if (currCart != null)
            {
                var check = new Check()
                {
                    Customer = currCart.Customer,
                    CustomerId = currCart.Customer.CustomerId,
                    Seller = Seller,
                    SellerId = Seller.SellerId,
                    DataCreated = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                }
                else
                {
                    check.CheckId = 0;
                }

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
                    summ += product.Price;
                    sells.Add(sell);

                    if (!IsModel)
                    {
                        db.Sells.Add(sell);
                    }
                    product.Count--;
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }

            return summ;
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
            }
            else
            {
                ExitCustomers++;
            }
        }
    }
}
