using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public static class Get1ItemSetsExtensions
    {
        public static async Task<List<Metrics1Item<T>>> OrderBySuportAsync<T>(this Task<List<Metrics1Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return await metrics;
        }


        public static async Task<List<Metrics1Item<T>>> OrderByDescendingSuportAsync<T>(this Task<List<Metrics1Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            (await metrics).Reverse();

            return await metrics;
        }



        public static List<Metrics1Item<T>> OrderBySuport<T>(this List<Metrics1Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return metrics;
        }



        public static List<Metrics1Item<T>> OrderByDescendingSuport<T>(this List<Metrics1Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            metrics.Reverse();

            return metrics;
        }
    }
}
