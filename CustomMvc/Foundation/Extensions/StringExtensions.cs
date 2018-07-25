using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
    public static class StringExtensions
    {
        public static string Base64Encode(this string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}