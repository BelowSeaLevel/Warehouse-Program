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
        /// This is meant for items already in the database that need a new amount value.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void UpdateDataB(string itemName, int itemAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE {itemName}, {itemAmount} INTO Stock";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    command.ExecuteNonQuery();

                    SqlDataReader dReader = command.ExecuteReader();

                    dt.Load(dReader);


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
