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
using System.Windows.Shapes;

namespace Warehouse_Program
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();

        }

        private void LBItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void GetDataBase()
        {
            ShowStock peek = new ShowStock();         // Makes a new ShowStock class.
            DataTable reading = peek.GetAllItems();     // Get all data from the ShowStock class, through the GetAllItems Method.
            ListBox.ItemsSource = reading.DefaultView;   // Default view gets the data in the database.
        }
    }

  
}
