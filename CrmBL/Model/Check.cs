﻿using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Check
    {
        public int CheckId { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public DateTime DataCreated { get; set; }

        public override string ToString()
        {
            return $"№{CheckId.ToString()} от {DataCreated.ToString("dd.MM.yyyy hh:mm:ss")}";
        }
    }
}
