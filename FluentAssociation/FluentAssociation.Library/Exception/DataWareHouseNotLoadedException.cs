namespace FluentAssociation.Library.Exception
{
    public class DataWareHouseNotLoadedException : System.Exception
    {
        public DataWareHouseNotLoadedException() : base("Data WareHouse not loaded previously.") { }
    }
}