using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CustomMvc.Foundation.Extensions
{
    public static class ClassMapper
    {
        public static T ConvertFromDynamic<T>(this DynamicObject obj)
        {
            return (T)obj.ConvertFromDynamic(typeof(T));
        }
        public static object ConvertFromDynamic(this DynamicObject obj, Type type)
        {
            object result = type.CreateInstance();
            foreach (PropertyInfo prop in type.GetProperties().Where(i => i.CanWrite))
            {
                try
                {
                    object value = obj.GetValue(prop);
                    if (value != null)
                    {
                        prop.SetValue(result, value);
                    }
                }
                catch (Exception ex) { }
            }
            return result;
        }
        public static T Convert<T>(this object obj)
        {
            Type type = typeof(T);
            Type baseType = obj.GetType();
            T result = type.CreateInstance<T>();
            foreach (PropertyInfo baseProp in baseType.GetProperties().Where(i => i.CanRead))
            {
                PropertyInfo prop = type.GetProperty(baseProp.Name, baseProp.PropertyType);
                result.SetValue(prop, obj, baseProp);
            }
            return result;
        }
        private static void SetValue(this object obj, PropertyInfo prop, object baseObj, PropertyInfo baseProp)
        {
            if (prop != null && prop.CanWrite && baseProp.CanRead)
            {
                object[] index = null;
                object[] value = baseProp.GetValue(baseObj, ref index);
                if (value != null && value.Length > 0)
                {
                    if (index != null && index.Length > 0)
                    {
                        for (int i = 0; i < index.Length; i++)
                        {
                            prop.SetValue(obj, value[i], new object[] { index[i] });
                        }
                    }
                    else
                    {
                        prop.SetValue(obj, value.FirstOrDefault());
                    }
                }
            }
        }
        private static object[] GetValue(this PropertyInfo prop, object obj, ref object[] index)
        {
            List<object> result = new List<object>();
            if (prop.CanRead)
            {
                try
                {
                    index = prop.GetIndex(obj);
                    if (index != null)
                    {
                        foreach (object i in index)
                        {
                            result.Add(prop.GetValue(obj, new object[] { i }));
                        }
                    }
                    else
                    {
                        result.Add(prop.GetValue(obj, null));
                    }
                }
                catch { }
            }
            return result.ToArray();
        }
        private static object[] GetIndex(this PropertyInfo prop, object obj)
        {
            object[] result = null;
            ParameterInfo[] indexParameters = prop.GetIndexParameters();
            if (indexParameters.Length > 0)
            {
                PropertyInfo[] indexProperties = obj.GetType().GetProperties().Where(
                    p => !p.CanWrite &&
                    p.PropertyType.IsEnumberable() &&
                    indexParameters.Have(p)
                ).ToArray();
                if (indexProperties.Length > 0)
                {
                    bool validIndex = true;
                    List<object[]> indexValues = new List<object[]>();
                    foreach (PropertyInfo indexProperty in indexProperties)
                    {
                        object[] indexValue = indexProperty.GetValue(obj).GetArray() ?? new object[] { };
                        if (indexValues.Count > 0 && indexValues.FirstOrDefault().Length != indexValue.Length)
                        {
                            validIndex = false;
                            break;
                        }
                        indexValues.Add(indexValue);
                    }
                    result = RenderIndexValues(validIndex, indexValues);
                }
            }
            return result;
        }
        private static bool Have(this ParameterInfo[] arr, PropertyInfo prop)
        {
            return arr.Count(i =>
                prop.Name.ToLower().Contains(i.Name.ToLower()) &&
                prop.Name.Length <= i.Name.Length + 2 &&
                prop.GetElementType() == i.ParameterType
            ) > 0;
        }
        private static Type GetElementType(this PropertyInfo prop)
        {
            Type type = prop.PropertyType;
            if (type.HasElementType)
                return type.GetElementType();
            else if (type.GenericTypeArguments != null)
                return type.GenericTypeArguments.FirstOrDefault();
            return null;
        }
        private static bool IsArray(this PropertyInfo prop)
        {
            if (prop.PropertyType.HasElementType)
                return true;
            return prop.PropertyType.GenericTypeArguments != null && prop.PropertyType.GenericTypeArguments.Length > 0;
        }
        private static object[] RenderIndexValues(bool validIndex, List<object[]> indexValues)
        {
            if (validIndex)
            {
                if (indexValues.Count > 1)
                {
                    List<object[]> index = new List<object[]>();
                    for (int i = 0; i < indexValues[0].Length; i++)
                    {
                        index.Add(indexValues.Select(value => value[i]).ToArray());
                    }
                    return index.ToArray();
                }
                else
                {
                    return indexValues.FirstOrDefault()?.ToArray();
                }
            }
            return null;
        }
        private static object[] GetArray(this object obj)
        {
            try
            {
                if (obj.GetType().IsEnumberable())
                {
                    return ((IEnumerable<object>)obj).ToArray();
                }
            }
            catch { }
            return null;
        }
        private static bool HasIndex(this PropertyInfo prop)
        {
            return prop.GetIndexParameters().Length > 0;
        }
        private static object GetValue(this DynamicObject obj, PropertyInfo prop)
        {
            object value = null;
            if (!prop.HasIndex())
            {
                if (prop.IsArray())
                {
                    value = obj.GetArray(prop);
                }
                else if (obj.IsObject(prop.Name))
                {
                    value = prop.PropertyType.CreateInstance();
                    DynamicObject baseValue = obj.GetObject(prop.Name);
                    if (baseValue != null)
                    {
                        foreach (PropertyInfo valueProp in prop.PropertyType.GetProperties().Where(i => i.CanWrite))
                        {
                            valueProp.SetValue(value, baseValue.GetValue(valueProp));
                        }

                    }
                }
                else
                {
                    value = obj.GetValue(prop.Name);
                    if (value != null)
                        value = System.Convert.ChangeType(value, prop.PropertyType);
                }
            }
            return value;
        }
        private static Array GetArray(this DynamicObject obj, PropertyInfo prop)
        {
            Type elementType = prop.GetElementType();
            Array array = Array.CreateInstance(elementType, obj.GetArrayLength(prop.Name));
            if (array.Length > 0)
            {
                if (obj.IsObject(prop.Name))
                {
                    array.SetValue(obj.GetObject(prop.Name).ConvertFromDynamic(elementType), 0);
                }
                else if (obj.IsObjectArray(prop.Name))
                {
                    DynamicObject[] values = obj.GetObjectArray(prop.Name);
                    for (int i = 0; i < values.Length; i++)
                    {
                        array.SetValue(values[i].ConvertFromDynamic(elementType), i);
                    }
                }
                else if (obj.IsArray(prop.Name))
                {
                    object[] values = obj.GetValueArray(prop.Name);
                    if (values != null)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            array.SetValue(System.Convert.ChangeType(values[i], elementType), i);
                        }
                    }
                }
                else
                {
                    array.SetValue(System.Convert.ChangeType(obj.GetValue(prop.Name), elementType), 0);
                }
            }
            return array;
        }
    }
}