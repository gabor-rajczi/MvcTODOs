using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcToDos.Dtos
{
    public class TeendoListaDto : TeendoBaseDto
    {
        [XmlArrayItem("TeendoElem")]
        public List<TeendoListaElemDto> TeendoListaElemek { get; set; }
    }
}