using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace TicTacToeWeb.Utils
{
    public class SessionHelper
    {
        public static void SaveValue(HttpContext context, string key, object obj)
        {
            context.Session.Set(key, ObjectToByteArray(obj));
        }

        public static object GetValue(HttpContext context, string key)
        {
            if(context.Session.Keys.Any(k => k == key))
            {
                byte[] value;
                var result = context.Session.TryGetValue(key, out value);
                
                if(result)
                {
                    return ByteArrayToObject(value);
                }
            }

            return null;
        }

        private static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        private static object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            object obj = (object)binForm.Deserialize(memStream);
            return obj;
        }
    }
}
