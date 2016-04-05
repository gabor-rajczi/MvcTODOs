using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToDos.Util
{
    public class PersisterResult
    {
        public string Content { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}