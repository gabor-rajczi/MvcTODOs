using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Entities
{
    public class TeendoListaElem
    {
        public virtual int Id { get; protected set; }

        public virtual string Szoveg { get; set; }

        public virtual TeendoLista Teendo { get; set; }
    }
}