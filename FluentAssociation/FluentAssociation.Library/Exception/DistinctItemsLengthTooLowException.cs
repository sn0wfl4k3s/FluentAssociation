namespace FluentAssociation.Library.Exception
{
    public class DistinctItemsLengthTooLowException : System.Exception
    {
        public DistinctItemsLengthTooLowException() : base("The distinct items length is too low that the ReportItemSet requested.") { }
    }
}
