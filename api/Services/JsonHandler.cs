using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services
{
    public static class JsonHandler
    {
        public static List<T> ToListGeneric<T>(string jsonArray) 
        {
            if (jsonArray == null)
            {
               return new List<T>();
            }

            return JsonConvert.DeserializeObject<List<T>>(jsonArray) ?? new List<T>();
        }

         public static T ToObjectGeneric<T>(string jsonArray) where T : class
        {
            if (jsonArray == null)
            {
                return null;
            }

            try
            {
                var r = JsonConvert.DeserializeObject<T>(jsonArray);
                return r;
                
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}