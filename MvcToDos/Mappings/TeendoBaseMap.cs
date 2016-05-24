using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcToDos.Entities;

namespace MvcToDos.Mappings
{
    public class TeendoBaseMap : ClassMap<TeendoBase>
    {
        public TeendoBaseMap()
        {
            Id(x => x.Id)
                .Not.Nullable();
            DiscriminateSubClassesOnColumn("TeendoTipus")
                .Not.Nullable();
            Map(x => x.Allapot)
                .Not.Nullable();
            Map(x => x.Letrehozas)
                .Not.Nullable();
            Map(x => x.Hatarido)
                .Nullable();
            Map(x => x.Fontossag)
                .Nullable();
            Map(x => x.SzinKod)
                .Nullable();
            Table("Teendo");
        }
    }
}