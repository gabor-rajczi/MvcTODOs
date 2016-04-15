using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public class TeendoLista : TeendoBase
    {
        public List<TeendoListaElem> TeendoListaElemek { get; set; }

        public TeendoLista()
        {
            TeendoListaElemek = new List<TeendoListaElem>();
        }
    }
}