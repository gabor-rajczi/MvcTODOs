using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Entities
{
    public class Teendo : TeendoBase
    {
        public virtual string Szoveg { get; set; }
    }
}