using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Entities
{
    public class TeendoBase
    {
        public virtual int Id { get; protected set; }

        public virtual bool Allapot { get; set; }

        public virtual DateTime Letrehozas { get; set; }

        public virtual DateTime? Hatarido { get; set; }

        public virtual string Fontossag { get; set; }

        public virtual string SzinKod { get; set; }
    }
}