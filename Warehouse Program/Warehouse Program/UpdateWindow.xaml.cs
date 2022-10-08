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

        /// <summary>
        /// Gets Database information for the UpdateWindow
        /// </summary>
        private void GetDataBase()
        {
            DBActions actions = new DBActions();
            DataTable item = actions.ActionGetAllItems();    // Get all data from the ShowStock class, through the GetAllItems Method.

            foreach (DataRow row in item.Rows)
            {
                LBItems.Items.Add(row[0]);   // Show the names of the items in the ListBox
            }


        }

        // Listbox item.
        private void LBItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBItems.SelectedItem != null)   // If we have something selected.
            { 
                selectedName = LBItems.SelectedItem.ToString(); // then 'selectedName' is set to the name of that item.
            }
        }


        
        // Button that gets the stock data.
        private void BT_GetStock_Click(object sender, RoutedEventArgs e)
        {
            LBItems.UnselectAll();  // Unselects all items.
            LBItems.Items.Clear();  // Clears the listbox, before refilling it.
            GetDataBase();          // Calls the GetDataBase method.
        }

        // Textbox for the name.
        private void TB_Naam_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemNaam = TB_Naam.Text;
        }

        // Textbox for the amount.
        private void TB_Aantal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // With this 'if' statement we make sure, that we won't get 2 Exceptions.
                // Because that would call the MessageBox twice.
                if (TB_Aantal.Text != "")
                {
                    itemAantal = int.Parse(TB_Aantal.Text); // Parses the input into an integer.
                }

            }
            catch (FormatException)
            {
                TB_Aantal.Clear();
                MessageBox.Show("Het 'Aantal' tekstveld verwacht een nummer!", "Waarschuwing");
            }
        }

        // Textbox for the part number
        private void TB_PartNummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemPartnummer = TB_PartNummer.Text;
        }

        // The Oke button click event.
        private void Oke_Click(object sender, RoutedEventArgs e)
        {
            DBActions actions = new DBActions();
            
            if (TB_Aantal.Text != "")
            {
                actions.ActionUpdateDataB(itemNaam, itemAantal, itemPartnummer, selectedName);   // Updates the database with the values given.

            }
            else
            {
                MessageBox.Show("Vul een 'Aantal' in! \nAnders reset je het aantal naar 0.", "Waarschuwing");
            }

            // Clears the textboxes.
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
                DBActions actions = new DBActions();
                actions.ActionDeleteItem(selectedName);
                MessageBox.Show($"{selectedName} is verwijdert!");
            }
            else if (result == MessageBoxResult.No)
            {
                // If no, we do nothing.
            }

            
        }
    }

  
}
