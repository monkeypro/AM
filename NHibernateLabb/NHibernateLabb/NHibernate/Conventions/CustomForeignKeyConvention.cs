﻿using System;
using FluentNHibernate.Conventions;
using FluentNHibernate;

namespace NHibernateLabb.NHibernate.Conventions
{
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
            {
                return type.Name + "Id";
            }

            return property.Name + "Id";
        }
    }
}
