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


        /// <summary>
        /// For all incomming items.
        /// This means the items will be increased in count.
        /// as this is new items comming into the warehouse.
        /// </summary>
        private void BTIncomming_Click(object sender, RoutedEventArgs e)
        {
            IncommingWindow incommingWindow = new IncommingWindow();
            incommingWindow.Show();
        }



        /// <summary>
        /// For all outgoing Items.
        /// This means items are going out of the warehouse
        /// to the customers.
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
        /// Update's the database, incase your database does not match the physical stock.
        /// </summary>
        private void BTUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow window = new UpdateWindow();
            window.Show();
            
        }
    }
}
