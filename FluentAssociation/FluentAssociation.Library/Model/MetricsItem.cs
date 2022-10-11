using System.Collections.Generic;
using System.Linq;

namespace FluentAssociation.Library.Model
{
    public class MetricsItem<T>
    {
        public IEnumerable<T> Items { get; set; }
        public float Suport { get; set; }
        public float? Confidence { get; set; }
        public IEnumerable<T> ItemsX => Items.SkipLast(1);
        public T ItemY => Items.LastOrDefault();
    }
}
