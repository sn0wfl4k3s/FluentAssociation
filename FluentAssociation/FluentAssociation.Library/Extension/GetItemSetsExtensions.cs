using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public static class GetItemSetsExtensions
    {
        public static async Task<List<MetricsItem<T>>> OrderBySuportAsync<T>(this Task<List<MetricsItem<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return await metrics;
        }

        public static async Task<List<MetricsItem<T>>> OrderByConfidenceAsync<T>(this Task<List<MetricsItem<T>>> metrics)
        {
            if((await metrics).Any(m => m.Confidence.HasValue))
            {
                (await metrics).Sort((a, b) => a.Confidence.Value.CompareTo(b.Confidence));
            }

            return await metrics;
        }

        public static async Task<List<MetricsItem<T>>> OrderByDescendingSuportAsync<T>(this Task<List<MetricsItem<T>>> metrics)
        {
            (await metrics).Sort((a, b) => a.Suport.CompareTo(b.Suport));

            (await metrics).Reverse();

            return await metrics;
        }

        public static async Task<List<MetricsItem<T>>> OrderByDescendingConfidenceAsync<T>(this Task<List<MetricsItem<T>>> metrics)
        {
            if ((await metrics).Any(m => m.Confidence.HasValue))
            {
                (await metrics).Sort((a, b) => a.Confidence.Value.CompareTo(b.Confidence));
            }

            (await metrics).Reverse();

            return await metrics;
        }

        public static List<MetricsItem<T>> OrderBySuport<T>(this List<MetricsItem<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            return metrics;
        }

        public static List<MetricsItem<T>> OrderByConfidence<T>(this List<MetricsItem<T>> metrics)
        {
            if (metrics.Any(m => m.Confidence.HasValue))
            {
                metrics.Sort((a, b) => a.Confidence.Value.CompareTo(b.Confidence));
            }

            return metrics;
        }

        public static List<MetricsItem<T>> OrderByDescendingSuport<T>(this List<MetricsItem<T>> metrics)
        {
            metrics.Sort((a, b) => a.Suport.CompareTo(b.Suport));

            metrics.Reverse();

            return metrics;
        }

        public static List<MetricsItem<T>> OrderByDescendingConfidence<T>(this List<MetricsItem<T>> metrics)
        {
            if (metrics.Any(m => m.Confidence.HasValue))
            {
                metrics.Sort((a, b) => a.Confidence.Value.CompareTo(b.Confidence));
            }

            metrics.Reverse();

            return metrics;
        }

        public static MetricsItem<T> GetItemSet<T>(this List<MetricsItem<T>> metrics, params T[] items)
        {
            return metrics.FirstOrDefault(m => m.Items.SkipLast(1).All(i => items.Contains(i)));
        }

        public static async Task<MetricsItem<T>> GetItemSet<T>(this Task<List<MetricsItem<T>>> metrics, T itemY, params T[] itemX)
        {
            return (await metrics)
                .FirstOrDefault(m => m.Items.Last().Equals(itemY) && m.Items.SkipLast(1).All(i => itemX.Contains(i)));
        }
    }
}
