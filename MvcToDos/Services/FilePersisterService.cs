using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MvcToDos.Util;

namespace MvcToDos.Services
{
    public class FilePersisterService : IPersisterService
    {
        public PersisterResult Load(Uri uri)
        {
            var result = new PersisterResult();
            try
            {
                using (var reader = new StreamReader(uri.AbsolutePath))
                {
                    result.Content = reader.ReadToEnd();
                }
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public PersisterResult Save(Uri uri, string persistableItem)
        {
            var result = new PersisterResult();
            try
            {
                using (var writer = new StreamWriter(uri.AbsolutePath))
                {
                    writer.Write(persistableItem);
                }
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}