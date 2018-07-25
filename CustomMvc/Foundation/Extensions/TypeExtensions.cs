using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
    public static class TypeExtensions
    {
        public static string GetControllerName(this Type type)
        {
            return type.Name.Replace("Controller", "").Replace("controller", "");
        }
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
        public static object CreateInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }
        public static T CreateInstance<T>(this Type type)
        {
            return (T)type.CreateInstance();
        }
    }
}