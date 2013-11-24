﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mijay.Utils.Reflection;

namespace NClone.Utils
{
    internal static class LazyTypeDetector
    {
        public static bool IsLazyType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Lazy<>))
                return true;
            if (type.ImplementsGenericInterface(typeof (IQueryable<>)) || typeof (IQueryable).IsAssignableFrom(type) ||
                type.ImplementsGenericInterface(typeof (IEnumerable<>)) || typeof (IEnumerable).IsAssignableFrom(type) ||
                type.ImplementsGenericInterface(typeof (IEnumerator<>)) || typeof (IEnumerator).IsAssignableFrom(type))
                if (!IsCollection(type))
                    return true;

            return false;
        }

        private static bool IsCollection(Type type)
        {
            return type.ImplementsGenericInterface(typeof (ICollection<>))
                   || typeof (ICollection).IsAssignableFrom(type)
                   || type.ImplementsGenericInterface(typeof (IReadOnlyCollection<>))
                   || type.Name.EndsWith("Collection", StringComparison.InvariantCulture)
                   || type.Name.EndsWith("List", StringComparison.InvariantCulture);
        }
    }
}