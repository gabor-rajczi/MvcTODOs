using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcToDos.Dtos;

namespace MvcToDos.Models
{
    public class TeendokListaja
    {
        public List<ITeendo> Teendok { get; set; }

        public TeendokListaja()
        {
            Teendok = new List<ITeendo>();
        }

        public TeendokListaja UjTeendo(ITeendo ujTeendo)
        {
            ujTeendo.Id = Teendok.Any() ? Teendok.Max(t => t.Id)+1 : 1;
            if (!ujTeendo.SzinkodMegadva)
            {
                ujTeendo.SzinKod = null;
            }
            Teendok.Add(ujTeendo);
            /*
            var lista = new TeendoLista()
            {
                TeendoListaElemek = new List<TeendoListaElem>()
                {
                    new TeendoListaElem()
                    {
                        Szoveg = "teszt",
                        Id = 1
                    },
                    new TeendoListaElem()
                    {
                        Szoveg = "tesztetzst",
                        Id = 2
                    },
                }
            };
            Teendok.Add(lista);
             */
            return this;
        }

        public ITeendo AllapotValtas(int id, bool allapot)
        {
            var teendo = Teendok.FirstOrDefault(t => t.Id == id);
            if (teendo != null)
            {
                teendo.Allapot = allapot;
            }
            return teendo;
        }

        public TeendokListaja TeendoTorlese(int id)
        {
            var teendo = Teendok.FirstOrDefault(t => t.Id == id);
            if (teendo != null)
            {
                Teendok.Remove(teendo);
            }
            return this;
        }

        public ITeendo FontossagAllitasa(int id, Fontossag.Tipus fontossag)
        {
            var teendo = Teendok.FirstOrDefault(t => t.Id == id);
            if (teendo != null)
            {
                teendo.Fontossag = fontossag;
            }
            return teendo;
        }
    }
}