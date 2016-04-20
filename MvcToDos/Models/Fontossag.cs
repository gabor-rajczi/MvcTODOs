using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public static class Fontossag
    {
        public enum Tipus
        {
            Alacsony,
            Normal,
            Magas
        }

        public static string ToUI(this Tipus source)
        {
            var fontossag = "";
            switch (source)
            {
                    case Tipus.Alacsony:
                    fontossag = "Alacsony";
                    break;
                    case Tipus.Normal:
                    fontossag = "Normál";
                    break;
                    case Tipus.Magas:
                    fontossag = "Magas";
                    break;
            }
            return fontossag;
        }

        public static bool IsAlacsony(this Tipus source)
        {
            return source == Tipus.Alacsony;
        }

        public static bool IsNormal(this Tipus source)
        {
            return source == Tipus.Normal;
        }

        public static bool IsMagas(this Tipus source)
        {
            return source == Tipus.Magas;
        }

        public static Tipus ToTipus(string source)
        {
            return (Tipus)Enum.Parse(typeof (Tipus), source);
        }
    }
}