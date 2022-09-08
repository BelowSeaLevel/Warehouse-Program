using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        }


        private void Export_Click(object sender, RoutedEventArgs e)
        {
            // How to Export to Excel??
            DataTable dataTable = new DataTable();
            ShowStock showStock = new ShowStock();
            dataTable = showStock.GetAllItems();

            MessageBox.Show("Exporting Items.");
        }

        // Resets the weekly difference in Received and Issued items.
        private void Reset_W_Verschil(object sender, RoutedEventArgs e)
        {
            UpdateDB updateDB = new UpdateDB();
            updateDB.ResetWeekly();
            MessageBox.Show("Week aantallen zijn ge-reset!");
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
        private void ShowStock_Click(object sender, RoutedEventArgs e)
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
    }
}
