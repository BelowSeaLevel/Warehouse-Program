using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Warehouse_Program
{
    internal class InsertItems
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();

        /// <summary>
        /// Inserts items into the database.
        /// </summary>
        internal DataTable InsertItemsDB(string itemName, int itemAmount, string partNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"INSERT INTO Stock (Name, Amount, Part Number) VALUES ({itemName}, {itemAmount}, {partNumber})";

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
                MessageBox.Show("An Excepption has occurred!" + " Source: " + e.Message);
                return null;
            }

        }
    }
}
