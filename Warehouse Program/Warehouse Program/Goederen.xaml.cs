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
    /// Interaction logic for OutgoingWindow.xaml
    /// </summary>
    public partial class GoederenWindow : Window
    {
        readonly string[] seperators = { "\r", "\n" };
        string[] scanned;
        Dictionary<string, int> finalAmounts = new Dictionary<string, int>();

        public GoederenWindow()
        {
            InitializeComponent();
            Scanned_Text.Focus();   // Sets the RichTextBox called Scanned_Text into focus.
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void B_Min_Click(object sender, RoutedEventArgs e)
        {
            finalAmounts.Clear();

            SplitArray();
            
            
            DBActions actions = new DBActions();
            foreach(var item in finalAmounts)
            {
                actions.ActionDecreaseDB(item.Key, item.Value);
            }

            Scanned_Text.Document.Blocks.Clear();
        }

        private void B_Plus_Click(object sender, RoutedEventArgs e)
        {
            // Clears the Dictionary, otherwise counts would stack.
            // And you would get a wrong amount updated.
            finalAmounts.Clear();


            SplitArray();


            // Update the Database "Aantal" Column based on the amount of times
            // a word has been scanned.
            DBActions actions = new DBActions();
            foreach (var item in finalAmounts)
            {
                actions.ActionIncreaseDB(item.Key, item.Value);
            }

            Scanned_Text.Document.Blocks.Clear();
        }


        // Splits the array in only the words we need, so we can update the Datebase.
        private void SplitArray()
        {
            int count;
            // Makes an array filled with all words in the Scanned_Text Document.
            // And splits it based on the seperators array.
            scanned = new TextRange(Scanned_Text.Document.ContentStart, Scanned_Text.Document.ContentEnd).Text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            

            // Foreach item in scanned, we check or it is already in finalAmounts,
            // If it is, we do it's value + 1.
            // If it is not yet in finalAmounts, we add it as new with count being 1.
            foreach (string item in scanned)
            {
                if(finalAmounts.ContainsKey(item))
                {
                    count = finalAmounts[item];
                    count++;
                    finalAmounts[item] = count;
                }
                else if (!finalAmounts.ContainsKey(item))
                { 
                    count = 1;
                    finalAmounts.Add(item, count);
                }
            }

        }
    }
}
