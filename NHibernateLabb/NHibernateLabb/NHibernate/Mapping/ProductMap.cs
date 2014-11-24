using NHibernateLabb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.NHibernate.Mapping
{
    public class ProductMap : EntityMapBase<Product>
    {
        public ProductMap()
        {
            Map(x => x.Name)
                .Not.Nullable();

            Map(x => x.Price)
                .Not.Nullable();
        }
    }
}