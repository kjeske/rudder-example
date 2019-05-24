using System;
using System.Collections.Immutable;

namespace RudderExample.Extensions
{
    public static class ImmutableListExtensions
    {
        public static ImmutableList<T> SetItem<T>(this ImmutableList<T> list, Predicate<T> predicate, Func<T, T> newItem)
        {
            var item = list.Find(predicate);

            return item != null 
                ? list.SetItem(list.IndexOf(item), newItem(item)) 
                : list;
        } 
    }
}