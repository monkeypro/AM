using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateLabb.Entities
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}