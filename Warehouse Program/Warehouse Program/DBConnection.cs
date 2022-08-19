using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Warehouse_Program
{
    public class DBConnection
    {
        internal readonly string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    }
}
