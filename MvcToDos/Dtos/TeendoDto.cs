﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcToDos.Dtos
{
    public class TeendoDto
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string Szoveg { get; set; }

        [XmlAttribute]
        public bool Allapot { get; set; }

        [XmlAttribute]
        public string Letrehozas { get; set; }

        [XmlAttribute]
        public string Hatarido { get; set; }

        [XmlAttribute]
        public string Fontossag { get; set; }

        [XmlAttribute]
        public string SzinKod { get; set; }

    }
}