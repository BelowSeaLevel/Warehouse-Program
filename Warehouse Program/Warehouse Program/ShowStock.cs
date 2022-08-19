using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Warehouse_Program
{
    
    internal class ShowStock
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();

        /// <summary>
        /// Returns what in the database.
        /// </summary>
        internal DataTable GetAllItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = "SELECT * FROM Stock";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    command.ExecuteNonQuery();

                    SqlDataReader dReader = command.ExecuteReader();

                    dt.Load(dReader);


                    command.Dispose();

                    return dt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Source: " + e.Source + "\n" + "Message: " + e.Message + "\n" + "StackTrace: " + e.StackTrace);
                return null;
            }

        }
    }
}
