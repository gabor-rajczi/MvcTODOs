using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcToDos.Util;

namespace MvcToDos.Services
{
    public interface IPersisterService
    {
        PersisterResult Load(Uri uri);
        PersisterResult Save(Uri uri, string persistableItem);
    }
}