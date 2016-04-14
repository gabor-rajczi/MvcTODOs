using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public class TeendokListaja
    {
        public List<Teendo> Teendok { get; set; }

        public TeendokListaja()
        {
            Teendok = new List<Teendo>();
        }

        public TeendokListaja UjTeendo(Teendo ujTeendo)
        {
            var id = Teendok.Any() ? Teendok.Max(t => t.Id)+1 : 1;
            ujTeendo.Id = id;
            Teendok.Add(ujTeendo);
            return this;
        }

        public Teendo AllapotValtas(int id, bool allapot)
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

        public Teendo FontossagAllitasa(int id, Teendo.FontossagTipus fontossag)
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