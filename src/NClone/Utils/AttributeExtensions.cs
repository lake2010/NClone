﻿using System.Linq;
using System.Reflection;

namespace NClone.Utils
{
    internal static class AttributeExtensions
    {
        /// <summary>
        /// Checks whether <paramref name="memberOrType"/> has specific attribute <typeparamref name="TAttribute"/>.
        /// </summary>
        public static bool HasAttribute<TAttribute>(this MemberInfo memberOrType)
        {
            return memberOrType.GetCustomAttributes(typeof(TAttribute), true).Any();
        }
    }
}