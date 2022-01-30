using System;
using System.Collections.Generic;
using System.Linq;

namespace RudderExample.Extensions
{
    public static class ImmutableListExtensions
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> list, Func<T, bool> predicate, Func<T, T> newItem)
        {
            var item = list.FirstOrDefault(predicate);

            return item != null 
                ? list.Select(i => i.Equals(item) ? newItem(item) : i) 
                : list;
        } 
    }
}