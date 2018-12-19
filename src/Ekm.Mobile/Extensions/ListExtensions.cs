using System.Collections.Generic;

namespace Ekm.Mobile.Extensions
{
    public static class ListExtensions
    {
        public static void AddAll<T>(this IList<T> self, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                self.Add(item);
            }
        }
        public static void Swap<T>(this IList<T> list, int from, int to)
        {
            T tmp = list[from];
            list[from] = list[to];
            list[to] = tmp;
        }
    }
}
