using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
    public interface IDynamicObject
    {
        bool IsObject(string key);
        DynamicObject GetObject(string key);
        T GetObject<T>(string key) where T : DynamicObject;
        DynamicObject[] GetObjectArray(string key);
        T[] GetObjectArray<T>(string key) where T : DynamicObject;
        object GetValue(string key);
        T GetValue<T>(string key);
        object[] GetValueArray(string key);
        T[] GetValueArray<T>(string key);
    }
    public class DynamicObject : Dictionary<string, object>, IDynamicObject
    {
        private object _GetValue(string key)
        {
            if (ContainsKey(key))
                return this[key];
            return null;
        }
        public bool IsObject(string key)
        {
            return _GetValue(key) is IDynamicObject;
        }
        public bool IsObjectArray(string key)
        {
            object value = _GetValue(key);
            if (value is Array)
            {
                object[] values = (object[])value;
                return values != null && values.Length > 0 && values[0] is IDynamicObject;
            }
            return false;
        }
        public bool IsArray(string key)
        {
            return _GetValue(key) is Array;
        }
        public int GetArrayLength(string key)
        {
            object[] values = GetValueArray(key);
            if (values != null)
                return values.Length;
            return ContainsKey(key) ? 1 : 0;
        }
        public DynamicObject GetObject(string key)
        {
            object value = _GetValue(key);
            if (value is Array)
                return null;
            return (DynamicObject)value;
        }
        public T GetObject<T>(string key) where T : DynamicObject
        {
            return GetObject(key)?.Convert<T>();
        }
        public DynamicObject[] GetObjectArray(string key)
        {
            object value = _GetValue(key);
            if (value is Array)
                return ((object[])value).Select(i => (DynamicObject)i).ToArray();
            return null;
        }
        public T[] GetObjectArray<T>(string key) where T: DynamicObject
        {
            return GetObjectArray(key)?.Select(i => i.Convert<T>()).ToArray();
        }
        public object GetValue(string key)
        {
            object value = _GetValue(key);
            if (value is Array)
                return null;
            return value;
        }
        public T GetValue<T>(string key)
        {
            return GetValue(key).ChangeType<T>();
        }
        public object[] GetValueArray(string key)
        {
            object value = _GetValue(key);
            if (value is Array)
                return (object[])value;
            return null;
        }
        public T[] GetValueArray<T>(string key)
        {
            return GetValueArray(key)?.Select(i => i.ChangeType<T>()).ToArray();
        }
    }
}