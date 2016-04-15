﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MvcToDos.Models
{
    public class TeendoBase
    {
        public enum FontossagTipus
        {
            Alacsony,
            Normal,
            Magas
        }
        public int Id { get; set; }
        
        public bool Allapot { get; set; }

        public DateTime Letrehozas { get; set; }

        [Display(Name = "Határidő")]
        public DateTime? Hatarido { get; set; }

        [Display(Name = "Fontosság")]
        public FontossagTipus Fontossag { get; set; }

        [Display(Name = "Szinkód")]
        public string SzinKod { get; set; }

        public bool SzinkodMegadva { get; set; }

        public TeendoBase()
        {
            Allapot = false;
            Letrehozas = DateTime.Now;
            Fontossag = FontossagTipus.Normal;
        }

        public string HataridoToString()
        {
            return Hatarido == null ? "nincs megadva" : ((DateTime)Hatarido).ToString("yyyy. MM. dd.");
        }

        public string FontossagToString()
        {
            var fontossag = String.Empty;
            switch (Fontossag)
            {
                case FontossagTipus.Normal:
                    fontossag = "Normál";
                    break;
                case FontossagTipus.Magas:
                    fontossag = "Magas";
                    break;
                case FontossagTipus.Alacsony:
                    fontossag = "Alacsony";
                    break;
            }
            return fontossag;
        }
    }
}