using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public class TeendokListaja
    {
        public List<Teendo> Teendok { get; set; }
        public List<TeendoLista> TeendoListak { get; set; }

        public TeendokListaja()
        {
            Teendok = new List<Teendo>();
            TeendoListak = new List<TeendoLista>();
        }

        public TeendokListaja UjTeendo(Teendo ujTeendo)
        {
            ujTeendo.Id = GetNextId();
            if (!ujTeendo.SzinkodMegadva)
            {
                ujTeendo.SzinKod = null;
            }
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

        public Teendo FontossagAllitasa(int id, TeendoBase.FontossagTipus fontossag)
        {
            var teendo = Teendok.FirstOrDefault(t => t.Id == id);
            if (teendo != null)
            {
                teendo.Fontossag = fontossag;
            }
            return teendo;
        }

        private int GetNextId()
        {
            int idFromTeendok = 1;
            int idFromTeendoListak = 1;
            if (Teendok.Any())
            {
                idFromTeendok += Teendok.Max(t => t.Id);
            }
            if (TeendoListak.Any())
            {
                idFromTeendoListak += TeendoListak.Max(t => t.Id);
            }
            return idFromTeendok > idFromTeendoListak ? idFromTeendok : idFromTeendoListak;
        }
    }
}