using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcToDos.Entities;

namespace MvcToDos.Mappings
{
    public class TeendoListaMap : SubclassMap<TeendoLista>
    {
        public TeendoListaMap()
        {
            DiscriminatorValue(TeendoTipus.TeendoLista);
            HasMany(x => x.TeendoListaElemek)
                .Inverse()
                .Cascade.All();
        }
    }
}