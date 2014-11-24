using FluentNHibernate.Mapping;
using NHibernateLabb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.NHibernate.Mapping
{
    public class OrderMap : EntityMapBase<Order>
    {
        public OrderMap()
        {
            References(x => x.User)
                .Not.Nullable();

            Map(x => x.OrderNumber)
                .Not.Nullable();

            HasManyToMany(x => x.Products)
                .Table("OrderProduct");
        }
    }
}