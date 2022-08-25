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
        List<string> ItemsToList = new List<string>();
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
            SplitList();
            // update the Database "Aantal" Column based on the amount of times
            // a word has been scanned.
        }

        private void B_Plus_Click(object sender, RoutedEventArgs e)
        {

        }


        private void SplitList()
        {
            // Makes an array filled with all words in the Scanned_Text Document.
            // And splits it based on the seperators array.
            scanned = new TextRange(Scanned_Text.Document.ContentStart, Scanned_Text.Document.ContentEnd).Text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            // Put each word from the scanned array into a list.
            foreach (string word in scanned)
            {
                ItemsToList.Add(word);
            }

            // Make a dictionary with each word as key, and the amount of times it is
            // present in the "ItemsToList" as Value, so we can update that Value
            // for each time we read the same word.
            

            // We need to find the duplicates of a name, and count how many times that duplicate
            // is present.
            var duplicates = ItemsToList.GroupBy(x => x)
                   .Where(g => g.Count() > 1)
                   .Select(y => new { Name = y.Key, Count = y.Count() })
                   .ToList();


            foreach (var x in duplicates)
            {
                finalAmounts.Add(x.Name, x.Count);
            }


            var joined = string.Join(Environment.NewLine, ItemsToList.ToArray());

            MessageBox.Show(joined);
        }
    }
}
