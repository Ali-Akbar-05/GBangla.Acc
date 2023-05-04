using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAcc.Helper
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static void SetList<T>(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }

        public static IList<T> GetList<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            var ddd = JsonConvert.DeserializeObject<IList<T>>(value);
            return value == null ? default(IList<T>) : JsonConvert.DeserializeObject<IList<T>>(value);
            //return value == null ? default(T) :
            //    JsonConvert.DeserializeObject<T>(value);
        }
    }
}
