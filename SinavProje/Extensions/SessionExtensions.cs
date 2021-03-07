using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace SinavProje.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.Set(key, System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value));
        }
        public static T GetObject<T>(this ISession session, string key)
        {

            var value = session.Get(key);

            return value == null ? default(T) :
                JsonSerializer.Deserialize<T>(value);
        }
    }
}
