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
    internal class DBActions
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();

        /// <summary>
        /// Returns what in the database.
        /// </summary>
        internal DataTable ActionGetAllItems()
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
                return null; // Must return null, as this Method must always return something.
            }

        }


        /// <summary>
        /// Delets items from the Database.
        /// </summary>
        /// <param name="itemName"></param>
        internal void ActionDeleteItem(string itemName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    var query = $"DELETE FROM Stock WHERE Naam = @itemName";

                    SqlCommand command = new SqlCommand(query, connection);

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
        /// Inserts items into the database.
        /// </summary>
        internal void ActionInsertItemsDB(string itemName, int itemAmount, string partNumber)
        {
            try
            {
                // Using the 'using' statement here to close the connection  automatically
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    // Query that goes into the database
                    var query = $"INSERT INTO Stock VALUES (@itemName, @itemAmount, @partNumber, @UitDw, @OntvDw)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Adds the value's to the query string.
                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@partNumber", (object)partNumber ?? DBNull.Value); // Allows the partNumber to be Null, however we need to make the variable an object in order to work with DBNull.
                    command.Parameters.AddWithValue("@UitDW", 0);
                    command.Parameters.AddWithValue("@OntvDw", 0);


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


        /// <summary>
        /// Increases the 'Aantal' for every item.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void ActionIncreaseDB(string itemName, int itemAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET Aantal = Aantal + @itemAmount, [Ontv Dw] = [Ontv Dw] + @itemAmount WHERE Naam = @itemName";

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
        internal void ActionDecreaseDB(string itemName, int itemAmount)
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


        /// <summary>
        /// Updates items in the Database.
        /// This is meant for items already in the database that need a new amount value,
        /// name, or part number.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemAmount"></param>
        internal void ActionUpdateDataB(string itemName, int itemAmount, string partNumber, string updateName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET Naam = @itemName," +
                        $"Aantal = @itemAmount, [Part Nummer] = @partNumber WHERE Naam = @UpdateName";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@itemAmount", itemAmount);
                    command.Parameters.AddWithValue("@partNumber", (object)partNumber ?? DBNull.Value);
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


        /// <summary>
        /// Resets the weekly difference.
        /// </summary>
        internal void ActionResetWeekly()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dB.connectionString))
                {
                    DataTable dt = new DataTable();

                    var query = $"UPDATE Stock SET [Uit Dw] = 0,[Ontv Dw] = 0";

                    SqlCommand command = new SqlCommand(query, connection);



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
