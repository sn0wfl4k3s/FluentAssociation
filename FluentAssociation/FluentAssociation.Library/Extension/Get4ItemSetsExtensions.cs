using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentAssociation.Library.Extension
{
    public static class Get4ItemSetsExtensions
    {
        public static async Task<List<Metrics4Item<T>>> OrderBySuportAsync<T>(this Task<List<Metrics4Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return await metrics;
        }

        public static async Task<List<Metrics4Item<T>>> OrderByConfidenceAsync<T>(this Task<List<Metrics4Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            return await metrics;
        }

        public static async Task<List<Metrics4Item<T>>> OrderByDescendingSuportAsync<T>(this Task<List<Metrics4Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            (await metrics).Reverse();

            return await metrics;
        }

        public static async Task<List<Metrics4Item<T>>> OrderByDescendingConfidenceAsync<T>(this Task<List<Metrics4Item<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            (await metrics).Reverse();

            return await metrics;
        }

        public static List<Metrics4Item<T>> OrderBySuport<T>(this List<Metrics4Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return metrics;
        }

        public static List<Metrics4Item<T>> OrderByConfidence<T>(this List<Metrics4Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            return metrics;
        }

        public static List<Metrics4Item<T>> OrderByDescendingSuport<T>(this List<Metrics4Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            metrics.Reverse();

            return metrics;
        }

        public static List<Metrics4Item<T>> OrderByDescendingConfidence<T>(this List<Metrics4Item<T>> metrics)
        {
            metrics.Sort((a, b) => a.Confidence.CompareTo(b.Confidence));

            metrics.Reverse();

            return metrics;
        }
    }
}
