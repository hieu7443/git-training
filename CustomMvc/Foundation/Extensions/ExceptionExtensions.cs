using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
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