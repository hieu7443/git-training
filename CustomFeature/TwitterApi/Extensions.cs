using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CustomFeature.TwitterApi
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
}