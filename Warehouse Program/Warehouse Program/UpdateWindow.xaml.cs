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
        private string itemNaam;
        private int itemAantal;
        private string itemPartnummer;
        private string updateName;

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void LBItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateName = LBItems.SelectedItem.ToString();
        }


        private void GetDataBase()
        {
            ShowStock peek = new ShowStock();         // Makes a new ShowStock class.
            DataTable reading = peek.GetAllItems();     // Get all data from the ShowStock class, through the GetAllItems Method.
            
            foreach (DataRow row in reading.Rows)
            {
                LBItems.Items.Add(row[1]);   // Show the names of the items in the ListBox
            }
            
            
        }

        private void BT_GetStock_Click(object sender, RoutedEventArgs e)
        {
            GetDataBase();
        }

        private void TB_Naam_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemNaam = TB_Naam.Text;
        }

        private void TB_Aantal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // With this 'if' statement we make sure, that we won't get 2 Exceptions.
                // Because that would call the MessageBox twice.
                if (TB_Aantal.Text != "")
                {
                    itemAantal = int.Parse(TB_Aantal.Text);
                }

            }
            catch (FormatException)
            {
                TB_Aantal.Clear();
                MessageBox.Show("De 'Aantal' Textbox verwacht een nummer!");
            }
        }

        private void TB_PartNummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemPartnummer = TB_PartNummer.Text;
        }

        private void Oke_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB updateDB = new UpdateDB();
            updateDB.UpdateDataB(itemNaam, itemAantal, itemPartnummer, updateName);

            TB_Naam.Clear();
            TB_Aantal.Clear();
            TB_PartNummer.Clear();
        }
    }

  
}
