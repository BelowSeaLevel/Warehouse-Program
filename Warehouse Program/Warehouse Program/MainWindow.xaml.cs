using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Warehouse_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Label_Reminder.Visibility = Visibility.Collapsed;


            MondayCheck();
        }

        // Checks wether it is Monday between 7:00 & 8:00
        private void MondayCheck()
        {

            DateTime today = DateTime.Now;


            if (today.DayOfWeek == DayOfWeek.Monday && today.Hour >= 7 && today.Hour <= 8)
            {
                Label_Reminder.Visibility= Visibility.Visible;
            }
           
        }


        /// <summary>
        /// Exports Database to a Excel document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            //DataTable dataTable = new DataTable();  // Create a datatable to hold database data.
            ShowStock showStock = new ShowStock();  // Makes a new ShowStock Class.
            DataTable dataTable = showStock.GetAllItems();    // Fill the dataTable with the database data.

            // Below we use the SaveFileDialog to open a dialogwindow,
            // where we can save the file in the correct place.
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter="Excel Workbook|*.xlsx" } )
            {
                if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

        // Resets the weekly difference in Received and Issued items.
        private void Reset_W_Verschil(object sender, RoutedEventArgs e)
        {
            UpdateDB updateDB = new UpdateDB();
            updateDB.ResetWeekly();
            Label_Reminder.Visibility = Visibility.Collapsed;
            System.Windows.MessageBox.Show("Week aantallen zijn ge-reset!", "Melding");
        }


        /// <summary>
        /// Makes a new Window, where you can input new items into your stock.
        /// </summary>
        private void BTIncomming_Click(object sender, RoutedEventArgs e)
        {
            IncommingWindow incommingWindow = new IncommingWindow();
            incommingWindow.Show();
        }



        /// <summary>
        /// Makes a new Window, where you can increase or decrease the items amount you have.
        /// </summary>
        private void BTGoederen_Click(object sender, RoutedEventArgs e)
        {
            GoederenWindow outgoingWindow = new GoederenWindow();
            outgoingWindow.Show();
        }

        /// <summary>
        /// Gets the data from the database, and shows them in a DataWindow.
        /// </summary>
        private void BTStock_Click(object sender, RoutedEventArgs e)
        {
            ShowStock peek = new ShowStock();         // Makes a new ShowStock class.
            DataTable reading = peek.GetAllItems();     // Get all data from the ShowStock class, through the GetAllItems Method.
            DataWindow.ItemsSource = reading.DefaultView;   // Default view gets the data in the database.

        }


        /// <summary>
        /// Makes a new Window, where you can Update your stock.
        /// </summary>
        private void BTUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow window = new UpdateWindow();
            window.Show();
            
        }


        #region ButtonEnter And Leave
        private void BTUpdateEnter(object sender, RoutedEventArgs e)
        {
            BTUpdate.FontSize = 40;
        }

        
        private void BTUpdateLeave(object sender, RoutedEventArgs e)
        {
            BTUpdate.FontSize = 30;
        }

        private void BTGoederenEnter(object sender, RoutedEventArgs e)
        {
            BTGoederen.FontSize = 37;
        }


        private void BTGoederenLeave(object sender, RoutedEventArgs e)
        {
            BTGoederen.FontSize = 30;
        }

        private void BTInkomendEnter(object sender, RoutedEventArgs e)
        {
            BTIncomming.FontSize = 27;
        }


        private void BTInkomendLeave(object sender, RoutedEventArgs e)
        {
            BTIncomming.FontSize = 23;
        }

        private void BTStockEnter(object sender, RoutedEventArgs e)
        {
            BTStock.FontSize = 38;
        }


        private void BTStockLeave(object sender, RoutedEventArgs e)
        {
            BTStock.FontSize = 30;
        }

        #endregion
    }
}
