using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcToDos.Entities;

namespace MvcToDos.Mappings
{
    public class TeendoMap : SubclassMap<Teendo>
    {
        public TeendoMap ()
        {
            DiscriminatorValue(TeendoTipus.Teendo);
            Map(x => x.Szoveg);
        }
    }
}