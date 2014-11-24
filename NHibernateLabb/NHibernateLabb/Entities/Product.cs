using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.Entities
{
    public class Product : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual decimal Price { get; set; }
    }
}