﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcToDos.Dtos
{
    public class TeendoDto : TeendoBaseDto
    {
        public string Szoveg { get; set; }
    }
}