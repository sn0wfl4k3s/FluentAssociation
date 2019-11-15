namespace FluentAssociation.Domain
{
    public class Metrics2Item<T>
    {
        public T Item1 { get; set; }
        public T Item2 { get; set; }
        public float Suport { get; set; }
        public float Confidence { get; set; }
    }
}