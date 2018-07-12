using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.Models
{
    public interface IDynamicObject
    {
        bool IsObject(string key);
        DynamicObject GetObject(string key);
        T GetObject<T>(string key) where T : DynamicObject;
        object GetValue(string key);
        T GetValue<T>(string key);
    }
    public class DynamicObject : Dictionary<string, object>, IDynamicObject
    {
        public bool IsObject(string key)
        {
            return this[key] is IDynamicObject;
        }
        public DynamicObject GetObject(string key)
        {
            return (DynamicObject)this[key];
        }
        public T GetObject<T>(string key) where T : DynamicObject
        {
            return (T)this[key];
        }
        public object GetValue(string key)
        {
            return this[key];
        }
        public T GetValue<T>(string key)
        {
            return (T)this[key];
        }
    }
}