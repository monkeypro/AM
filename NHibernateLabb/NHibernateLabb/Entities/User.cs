using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.Entities
{
    public class User : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual IList<Order> Orders { get; protected set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}