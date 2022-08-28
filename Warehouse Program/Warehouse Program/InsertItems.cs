using System;
using System.Data.SqlClient;
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
        internal void InsertItemsDB(string itemName, int itemAmount, string partNumber)
        {
            try
            {
                // Using the 'using' statement here to close the connection  automatically
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    // Query that goes into the database
                    var query = $"INSERT INTO Stock VALUES (@itemName, @itemAmount, @partNumber)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Adds the value's to the query string.
                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@partNumber", (object)partNumber ?? DBNull.Value);
                    // Allows the above partNumber to be Null,
                    // however we need to make the variable an object in order to work with DBNull.



                    connection.Open();  // Opens the connection to database

                    command.ExecuteNonQuery();  // Executes the query

                    command.Dispose();  // Dispose of resources we don't need anymore
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Excepption has occurred!" + " Source: " + e.Message);
            }

        }
    }
}
