namespace SqlToLinq.Core.Common
{
    public class ConnectionStrings
    {
        public static readonly string AdoConnectionString =
            "Data Source =.; Initial Catalog = BikeStores; Integrated Security = True";
        
        public static readonly string EfConnectionString =
            "Server=.;Database=BikeStores;Trusted_Connection=True;";
    }
}
