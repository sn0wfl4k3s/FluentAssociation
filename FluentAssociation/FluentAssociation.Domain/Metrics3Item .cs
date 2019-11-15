namespace FluentAssociation.Domain
{
    public class Metrics3Item<T>
    {
        public T Item1 { get; set; }
        public T Item2 { get; set; }
        public T Item3 { get; set; }
        public float Suport { get; set; }
        public float Confidence { get; set; }
    }
}