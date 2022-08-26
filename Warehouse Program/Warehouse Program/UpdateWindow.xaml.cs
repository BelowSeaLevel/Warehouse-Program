using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
        private string selectedName;

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void LBItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBItems.SelectedItem != null)
            { 
                selectedName = LBItems.SelectedItem.ToString();
            }
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
            LBItems.UnselectAll();
            LBItems.Items.Clear();
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
            updateDB.UpdateDataB(itemNaam, itemAantal, itemPartnummer, selectedName);

            TB_Naam.Clear();
            TB_Aantal.Clear();
            TB_PartNummer.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox with Yes/No buttons. And a question / title for the window.
            MessageBoxResult result = MessageBox.Show($"Weet je zeker dat je '{selectedName}' wilt verwijderen?", "Item Verwijderen", MessageBoxButton.YesNo);
            
            // If the result is yes. We Delete the selected item. And show a message.
            if (result == MessageBoxResult.Yes)
            {
                DB_Delete_Item del = new DB_Delete_Item();
                del.DeleteItem(selectedName);
                MessageBox.Show($"{selectedName} is verwijdert!");
            }
            else if (result == MessageBoxResult.No)
            {
                
            }

            
        }
    }

  
}
