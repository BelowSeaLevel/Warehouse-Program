using System.Configuration;

namespace Warehouse_Program
{
    public class DBConnection
    {
        internal readonly string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    }
}
