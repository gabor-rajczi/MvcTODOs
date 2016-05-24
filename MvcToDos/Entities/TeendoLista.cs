using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Entities
{
    public class TeendoLista : TeendoBase
    {
        public virtual IList<TeendoListaElem> TeendoListaElemek { get; set; }

        public TeendoLista()
        {
            TeendoListaElemek = new List<TeendoListaElem>();
        }
    }
}