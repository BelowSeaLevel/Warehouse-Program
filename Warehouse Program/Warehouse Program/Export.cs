using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Program
{
    internal class Export
    {
        public void Exporting()
        {
            //DataTable dataTable = new DataTable();  // Create a datatable to hold database data.
            ShowStock showStock = new ShowStock();  // Makes a new ShowStock Class.
            DataTable dataTable = showStock.GetAllItems();    // Fill the dataTable with the database data.

            // Below we use the SaveFileDialog to open a dialogwindow,
            // where we can save the file in the correct place.
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook book = new XLWorkbook()) // Try to make a new workbook and save it.
                        {
                            book.AddWorksheet(dataTable, "Stocklijst");
                            book.SaveAs(sfd.FileName);
                        }
                        System.Windows.MessageBox.Show("Export succes.");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Message: " + ex.Message);
                    }
                }
            }
        }
    }
}
