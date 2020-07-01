using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Check
    {
        public int CheckId { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal Price 
        { 
            get
            {
                if (Sells == null)
                {
                    return 0;
                }
                decimal price = 0;
                foreach (var sell in Sells)
                {
                    price += sell.Product.Price;
                }
                return price;
            }
        }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public DateTime DataCreated { get; set; }

        public override string ToString()
        {
            return $"№{CheckId.ToString()}. Итого {Price.ToString()}, от {DataCreated.ToString("dd.MM.yyyy hh:mm:ss")}";
        }
    }
}
