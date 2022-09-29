using System.Collections.Generic;

namespace HuobiMapper.Extensions
{
    public static class ListExtensions
    {
        public static void AddObjectIfNotNull<T>(this List<T> list, T obj)
        {
            if (obj == null) return;
            list.Add(obj);
        }
    }
}
