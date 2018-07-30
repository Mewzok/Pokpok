using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace Pokpok
{
    /// <summary>
    /// Interaction logic for trainercreator.xaml
    /// </summary>
    public partial class trainercreator : Window
    {
        public trainercreator()
        {
            InitializeComponent();
        }

        private void tcCancButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tcSubButton_Click(object sender, RoutedEventArgs e)
        {
            string name = new TextRange(tNameBox.Document.ContentStart, tNameBox.Document.ContentEnd).Text.Trim();
            string tClass = tClassBox.SelectionBoxItem.ToString();

            trainer t1 = new trainer();

            t1.createTrainer(t1, name, tClass);
            tNameBox.Document.Blocks.Clear();
        }

        public string getTNameBox()
        {
            return new TextRange(tNameBox.Document.ContentStart, tNameBox.Document.ContentEnd).Text;
        }
    }
}
