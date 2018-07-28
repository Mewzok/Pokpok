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
            string name = tNameBox.Text;
            string tClass = tClassBox.SelectedItem.ToString();

            trainer t1 = new trainer();

            t1.createTrainer(name, tClass);
        }

        public void setTNameBox(string s)
        {
            tNameBox.Text = "Please?";
            tNameBox.
        }

        public string getTNameBox()
        {
            return tNameBox.Text;
        }
    }
}
