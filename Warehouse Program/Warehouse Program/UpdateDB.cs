using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Warehouse_Program
{
    internal class UpdateDB
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();  
        

        /// <summary>
        /// Updates items in the Database.
        /// This is meant for items already in the database that need a new amount value,
        /// name, or part number.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void UpdateDataB(string itemName, int itemAmount, string partNumber, string updateName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET Name = @itemName," +
                        $"Amount = @itemAmount, [Part Number] = @partNumber) WHERE Name = @UpdateName";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@partNumber", partNumber);
                    command.Parameters.AddWithValue("@UpdateName", updateName);

                    connection.Open();

                    command.ExecuteNonQuery();

                    command.Dispose();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Source: " + e.Source + "\n" + "Message: " + e.Message + "\n" + "StackTrace: " + e.StackTrace);

            }

        }
    }
}
