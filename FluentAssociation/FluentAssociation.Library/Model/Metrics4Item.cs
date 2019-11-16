﻿namespace FluentAssociation.Library.Model
{
    public class Metrics4Item<T>
    {
        public T Item1 { get; set; }
        public T Item2 { get; set; }
        public T Item3 { get; set; }
        public T Item4 { get; set; }
        public float Suport { get; set; }
        public float Confidence { get; set; }
    }
}