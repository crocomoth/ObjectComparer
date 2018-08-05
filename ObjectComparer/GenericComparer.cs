using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectComparer
{
    public class GenericComparer
    {
        public bool Compare<T>(T first, T second)
        {
            if (first == null || second == null)
            {
                return false;
            }

            return DeepCompare(first, second);
        }

        private bool DeepCompare<T>(T first,T second)
        {            
            var firstObjectType = first.GetType();
            var secondObjectType = second.GetType();

            if (firstObjectType != secondObjectType)
            {
                return false;
            }

            if (IsPrimitiveOrSimpleType(first))
            {
                if (first.Equals(second))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            var firstObjectFields = this.GetAllFields(firstObjectType);
            var secondObjectFields = this.GetAllFields(secondObjectType);

            foreach (var elem in firstObjectFields)
            {
                if (IsPrimitiveOrSimpleType(elem.GetValue(first)))
                {
                    if (!elem.GetValue(first).Equals(elem.GetValue(second)))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!DeepCompare(elem.GetValue(first), elem.GetValue(second)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetAllFields(Type type)
        {
            if (type == null)
            {
                return Enumerable.Empty<FieldInfo>();
            }

            BindingFlags flags = BindingFlags.Public |
                                 BindingFlags.NonPublic |
                                 BindingFlags.Static |
                                 BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;

            return type.GetFields(flags).Union(GetAllFields(type.BaseType));
        }

        private IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            if (type == null)
            {
                return Enumerable.Empty<PropertyInfo>();
            }

            BindingFlags flags = BindingFlags.Public |
                                 BindingFlags.NonPublic |
                                 BindingFlags.Static |
                                 BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;

            return type.GetProperties(flags).Union(GetAllProperties(type.BaseType));
        }

        private bool IsPrimitiveOrSimpleType(object obj)
        {
            Type objType = obj.GetType();

            if (objType.IsPrimitive || objType == typeof(string) || objType == typeof(decimal) || objType == typeof(DateTime) || objType == typeof(object))
            {
                return true;
            }

            return false;
        }
    }
}
