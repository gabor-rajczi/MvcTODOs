using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcToDos.Services
{
    public class XmlSerializeService : ISerializeService
    {
        public string Serialize<T>(T serializableItem)
        {
            var serializer = new XmlSerializer(typeof (T), new XmlRootAttribute("Root"));
            using (TextWriter result = new StringWriter()) { 
                serializer.Serialize(result, serializableItem);
                return result.ToString();
            }
        }

        public T Deserialize<T>(string deserializableItem)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("Root"));
            using (var item = new StringReader(deserializableItem))
            {
                T result = (T)serializer.Deserialize(item);
                return result;
            }
        }
    }
}