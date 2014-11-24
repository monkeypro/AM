using FluentNHibernate.Mapping;
using NHibernateLabb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.NHibernate.Mapping
{
    public class UserMap : EntityMapBase<User>
    {
        public UserMap()
        {
            Map(x => x.Name)
                .Not.Nullable();

            HasMany(x => x.Orders)
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}