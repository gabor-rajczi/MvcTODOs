using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Services
{
    public interface ISerializeService
    {
        string Serialize<T>(T serializableItem);
        T Deserialize<T>(string deserializableItem);
    }
}