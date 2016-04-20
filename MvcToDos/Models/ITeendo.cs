using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public interface ITeendo
    {
        int Id { get; set; }
        
        bool Allapot { get; set; }

        DateTime Letrehozas { get; set; }

        DateTime? Hatarido { get; set; }

        Fontossag.Tipus Fontossag { get; set; }

        string SzinKod { get; set; }

        bool SzinkodMegadva { get; set; }

        string HataridoToString();
    }
}