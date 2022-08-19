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
            // Makes an array filled with all words in the Scanned_Text Document.
            // And splits it based on the seperators array.
            scanned = new TextRange(Scanned_Text.Document.ContentStart, Scanned_Text.Document.ContentEnd).Text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            // Put each word from the scanned array into a list.
            foreach (string word in scanned)
            {
                ItemsToList.Add(word);
            }

            // Below we need to update the database, by removing that amount of times an item,
            // is scanned into the Scanned_Text Document.

            // We need to find the duplicates of a name, and count how many times that duplicate
            // is present.
            var duplicates = ItemsToList.GroupBy(x => x)
                   .Where(g => g.Count() > 1)
                   .Select(y => new { Name = y.Key, Count = y.Count() })
                   .ToList();


            var joined = string.Join(Environment.NewLine, ItemsToList.ToArray());

            //MessageBox.Show();
        }

        private void B_Plus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
