namespace FluentAssociation.Library.Exception
{
    public class QuantityGreaterThanDistinctItemsException : System.Exception
    {
        public QuantityGreaterThanDistinctItemsException() : base("The quantity is greater than the different items in the DataWareHouse.") { }
    }
}
