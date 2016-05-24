using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcToDos.Entities;

namespace MvcToDos.Mappings
{
    public class TeendoListaElemMap : ClassMap<TeendoListaElem>
    {
        public TeendoListaElemMap()
        {
            Id(x => x.Id);
            Map(x => x.Szoveg);
            References(x => x.Teendo);
            Table("TeendoListaElem");
        }
    }
}