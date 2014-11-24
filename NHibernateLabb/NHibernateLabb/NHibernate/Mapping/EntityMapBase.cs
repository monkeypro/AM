using FluentNHibernate.Mapping;
using NHibernateLabb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.NHibernate.Mapping
{
    public abstract class EntityMapBase<T> : ClassMap<T>
        where T : EntityBase
    {
        public EntityMapBase()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();
        }
    }
}