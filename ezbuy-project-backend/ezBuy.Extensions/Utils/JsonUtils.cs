using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ezBuy.Extensions.Utils
{
    public class JsonUtils
    {
        public static IEnumerable<T> DeserializeList<T>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                return JsonConvert.DeserializeObject<List<T>>(json);
            }

            return null;
        }

        public static T Deserialize<T>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default(T);
        }

        public static string Serialize<T>(T entity) => JsonConvert.SerializeObject(entity);

        public static string SerializeList<T>(IEnumerable<T> entity) => JsonConvert.SerializeObject(entity);

        public static T Clone<T>(T entity) => Deserialize<T>(Serialize<T>(entity));

        public static T Cast<T>(object entity) => Deserialize<T>(Serialize(entity));

        public static T Cast<T>(IEnumerable<object> entities) => Deserialize<T>(Serialize(entities));

        public static bool IsEquals(object left, object right) => Serialize(left) == Serialize(right);

    }
}
