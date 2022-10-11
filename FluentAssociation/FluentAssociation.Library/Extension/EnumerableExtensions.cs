using System.Collections.Generic;
using System.Linq;

namespace FluentAssociation.Library.Extension
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> CombinationsOf<T>(this IEnumerable<T> items, ushort quantity)
        {
            if (!items.Any() || quantity > items.Count())
            {
                return Enumerable.Empty<IEnumerable<T>>();
            }

            if (quantity == 2)
            {
                return items.CombinationOfTwo();
            }

            var head = items.First();

            var tail = items.Skip(1);

            var combinations = tail.CombinationsOf((ushort)(quantity - 1)).Select(subCombinations => new T[] { head }.Concat(subCombinations));

            return combinations.Concat(tail.CombinationsOf(quantity));
        }

        private static IEnumerable<IEnumerable<T>> CombinationOfTwo<T>(this IEnumerable<T> items)
        {
            if (!items.Any())
            {
                return Enumerable.Empty<IEnumerable<T>>();
            }

            var head = items.First();

            var tail = items.Skip(1);

            var combinations = tail.Select(element => new T[] { head, element });

            return combinations.Concat(tail.CombinationOfTwo());
        }
    }
}
