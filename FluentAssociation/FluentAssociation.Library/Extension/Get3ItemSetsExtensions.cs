using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public static class Get3ItemSetsExtensions
    {
        public static async Task<List<Metrics3Item<T>>> OrderBySuportAsync<T>(this Task<List<Metrics3Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return await metrics;
        }

        public static async Task<List<Metrics3Item<T>>> OrderByConfidenceAsync<T>(this Task<List<Metrics3Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            return await metrics;
        }

        public static async Task<List<Metrics3Item<T>>> OrderByDescendingSuportAsync<T>(this Task<List<Metrics3Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            (await metrics).Reverse();

            return await metrics;
        }

        public static async Task<List<Metrics3Item<T>>> OrderByDescendingConfidenceAsync<T>(this Task<List<Metrics3Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            (await metrics).Reverse();

            return await metrics;
        }

        public static List<Metrics3Item<T>> OrderBySuport<T>(this List<Metrics3Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return metrics;
        }

        public static List<Metrics3Item<T>> OrderByConfidence<T>(this List<Metrics3Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            return metrics;
        }

        public static List<Metrics3Item<T>> OrderByDescendingSuport<T>(this List<Metrics3Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            metrics.Reverse();

            return metrics;
        }

        public static List<Metrics3Item<T>> OrderByDescendingConfidence<T>(this List<Metrics3Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            metrics.Reverse();

            return metrics;
        }

        public static Metrics3Item<T> GetItemSet<T>(this List<Metrics3Item<T>> metrics, T itemX1, T itemX2, T itemY)
        {
            return metrics.Where(m => m.Item1.Equals(itemX1) && m.Item2.Equals(itemX2) && m.Item3.Equals(itemY)).First();
        }

        public static async Task<Metrics3Item<T>> GetItemSet<T>(this Task<List<Metrics3Item<T>>> metrics, T itemX1, T itemX2, T itemY)
        {
            return (await metrics).Where(m => m.Item1.Equals(itemX1) && m.Item2.Equals(itemX2) && m.Item3.Equals(itemY)).First();
        }
    }
}