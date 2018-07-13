using CustomFeature.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CustomFeature.Helpers
{
    public static class StringExtensions
    {
        public static string Base64Encode(this string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
    public static class ExceptionExtensions
    {
        public static Exception LastInnerException(this Exception e)
        {
            if (e.InnerException != null)
                return e.InnerException.LastInnerException();
            return e;
        }
    }
    public static class JsonExtensions
    {
        private static object GetValue(this JToken token)
        {
            object value = null;
            switch (token.Type)
            {
                case JTokenType.Array:
                    value = token.Select(i => GetValue(i)).ToArray();
                    break;
                case JTokenType.Object:
                    value = RenderObject<DynamicObject>(token);
                    break;
                case JTokenType.Boolean:
                    value = token.Value<bool>();
                    break;
                case JTokenType.Bytes:
                    value = token.Value<byte[]>();
                    break;
                case JTokenType.Date:
                    value = token.Value<DateTime>();
                    break;
                case JTokenType.Float:
                    value = token.Value<double>();
                    break;
                case JTokenType.Guid:
                    value = token.Value<Guid>();
                    break;
                case JTokenType.Integer:
                    value = token.Value<long>();
                    break;
                case JTokenType.TimeSpan:
                    value = token.Value<TimeSpan>();
                    break;
                case JTokenType.Uri:
                    value = token.Value<Uri>();
                    break;
                default:
                    value = token.Value<string>();
                    break;
            }
            return value;
        }
        public static T RenderObject<T>(this JToken token) where T : DynamicObject
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            foreach (JProperty prop in token.Select(i => (JProperty)i))
            {
                result.Add(prop.Name, GetValue(prop.Value));
            }
            return result;
        }
    }
    public static class TypeExtensions
    {
        public static bool IsEnumberable(this Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
        public static T ChangeType<T>(this object value)
        {
            T result = default(T);
            try
            {
                if (value != null)
                    result = (T)Convert.ChangeType(value, typeof(T));
            }
            catch { }
            return result;
        }
    }
}