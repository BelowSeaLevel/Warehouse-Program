using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Warehouse_Program
{
    internal class UpdateGoederen
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();


        /// <summary>
        /// Increases the 'Aantal' for every item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void IncreaseDB(string itemName, int itemAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET Aantal = Aantal + @itemAmount, [Ontv Dw] = [Ontv Dw] + @itemAmount =  WHERE Naam = @itemName";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@itemName", itemName);

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


        /// <summary>
        /// Decrease the 'Aantal' for every item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void DecreaseDB(string itemName, int itemAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET Aantal = Aantal - @itemAmount, [Uit Dw] = [Uit Dw] + @itemAmount WHERE Naam = @itemName";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@itemName", itemName);

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
