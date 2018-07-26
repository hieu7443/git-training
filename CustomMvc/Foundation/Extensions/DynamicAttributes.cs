using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
    public class DynamicField : Attribute
    {
        public DynamicField(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}