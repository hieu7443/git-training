using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CustomFeature.Helpers
{
    public static class ClassMapper
    {
        public static T Convert<T>(this object obj)
        {
            Type type = typeof(T);
            Type baseType = obj.GetType();
            T result = (T)Activator.CreateInstance(type);
            foreach (PropertyInfo baseProp in baseType.GetProperties().Where(i => i.CanRead))
            {
                PropertyInfo prop = type.GetProperty(baseProp.Name, baseProp.PropertyType);
                if (prop != null && prop.CanWrite)
                {
                    object[] index = null;
                    object[] value = baseProp.GetValue(obj, ref index);
                    if (value != null && value.Length > 0)
                    {
                        if (index != null && index.Length > 0)
                        {
                            for (int i = 0; i < index.Length; i++)
                            {
                                prop.SetValue(result, value[i], new object[] { index[i] });
                            }
                        }
                        else
                        {
                            prop.SetValue(result, value.FirstOrDefault());
                        }
                    }
                }
            }
            return result;
        }
        private static object[] GetValue(this PropertyInfo prop, object obj, ref object[] index)
        {
            List<object> result = new List<object>();
            if (prop.CanRead)
            {
                index = prop.GetIndex(obj);
                foreach (object i in index)
                {
                    result.Add(prop.GetValue(obj, new object[] { i }));
                }
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
                prop.Name.Length <= i.Name.Length + 2
            ) > 0;
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
    }
}