using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.Entities
{
    public class Order : EntityBase
    {
        public virtual User User { get; set; }

        public virtual int OrderNumber { get; set; }

        public virtual IList<Product> Products { get; protected set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}