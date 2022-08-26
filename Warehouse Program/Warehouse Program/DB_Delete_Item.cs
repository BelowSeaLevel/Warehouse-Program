﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Warehouse_Program
{
    internal class DB_Delete_Item
    {
        // New DBConnection Object, to get the database connectionstring
        private readonly DBConnection dB = new DBConnection();

        internal void DeleteItem(string itemName)
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
    }
}