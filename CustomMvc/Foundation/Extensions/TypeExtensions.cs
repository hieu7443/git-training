using System;
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
    }
}