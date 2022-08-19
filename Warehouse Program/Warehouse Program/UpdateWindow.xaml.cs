using System;
using System.Collections.Generic;
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

            List<DBItems> items = new List<DBItems>();
            items.Add(new DBItems() { name = "UTP 5 meter", amount = 40 });
            items.Add(new DBItems() { name = "T450", amount = 5 });


            foreach(DBItems item in items)
            {
                LBItems.Items.Add(item.name);
            }
        }

        private void LBItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }

    public class DBItems
    {
        public string name;
        public int amount;
    }
}
