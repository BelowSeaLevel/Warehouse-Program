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
    /// Interaction logic for IncommingWindow.xaml
    /// </summary>
    public partial class IncommingWindow : Window
    {
        private string itemName;
        private int itemAmount;
        private string partNumber;
        public IncommingWindow()
        {
            InitializeComponent();
        }

        private void Name_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemName = Name_Textbox.Text;
        }

        private void Amount_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // With this 'if' statement we make sure, that we won't get 2 Exceptions.
                // Because that would call the MessageBox twice.
                if (Amount_Textbox.Text != "")
                {
                    itemAmount = int.Parse(Amount_Textbox.Text);
                }

            }
            catch (FormatException)
            {
                Amount_Textbox.Clear();
                MessageBox.Show("The 'Amount' textbox needs a number as input!");
            }

        }

        private void PN_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            partNumber = PN_Textbox.Text;
        }

        private void Commit_Button_Click(object sender, RoutedEventArgs e)
        {
            InsertItems insert = new InsertItems();

            try
            {
                insert.InsertItemsDB(itemName, itemAmount, partNumber);
                MessageBox.Show("Items have been inserted into to the database!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception has occurred!" + ex.Message);
            }



            Name_Textbox.Clear();
            Amount_Textbox.Clear();
            PN_Textbox.Clear();
        }


    }
}
