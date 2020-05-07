using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Condominium.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static void RemoveAll<T>(this ICollection<T> target, Func<T, bool> predicate)
        {
            List<T> list = target as List<T>;
            if (list != null)
            {
                list.RemoveAll(new Predicate<T>(predicate));
            }
            else
            {
                List<T> itemsToDelete = target.Where(predicate).ToList();

                foreach (var item in itemsToDelete)
                {
                    target.Remove(item);
                }
            }
        }
    }
}
