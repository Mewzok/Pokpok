using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Pokpok
{
    /// <summary>
    /// Interaction logic for SelectTrainerTCWin.xaml
    /// </summary>
    public partial class SelectTrainerTCWin : Window
    {
        public SelectTrainerTCWin()
        {
            InitializeComponent();
            Application.Current.MainWindow.FontFamily = new FontFamily("Power Red and Green");
            showAvailableTrainers();
        }

        private void showAvailableTrainers()
        {
            trainer t = new trainer();
            int i = 0;
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves");

            string[] filePaths = Directory.GetFiles(dir.ToString(), "*.xml", SearchOption.TopDirectoryOnly);

            List<Button> backButtons = Enumerable.Repeat(default(Button), filePaths.Length).ToList();
            List<Grid> backGrids = Enumerable.Repeat(default(Grid), filePaths.Length).ToList();

            foreach (string s in filePaths)
            {
                createNewRow(t, filePaths, i, backButtons, backGrids);
                t = t.loadTrainer(filePaths[i]);
                i++;
            }
        }

        private void createNewRow(trainer t, string[] filePaths, int i, List<Button> backButtons, List<Grid> backGrids)
        {
            int j = i + 1;
            int distanceMod = 0;
            t = t.loadTrainer(filePaths[i]);

            MessageBox.Show(t.name);
            Label l1 = new Label();
            l1.Content = t.name;
            l1.FontFamily = new FontFamily("Power Red and Green");
            l1.FontSize = 24;
            l1.Margin = new Thickness(0, 0 * j, 564, 26 * j);

            Label l2 = new Label();
            l2.Content = t.tClass;
            l2.FontFamily = new FontFamily("Power Red and Green");
            l2.FontSize = 24;
            l2.Margin = new Thickness(0, 30 * j, 574, 0 * j);

            Label l3 = new Label();
            l3.Content = "$";
            l3.FontFamily = new FontFamily("Power Red and Green");
            l3.FontSize = 24;
            l3.Margin = new Thickness(218, 0 * j, 539, 30 * j);

            Label l4 = new Label();
            l4.Content = t.money;
            l4.FontFamily = new FontFamily("Power Red and Green");
            l4.FontSize = 24;
            l4.Margin = new Thickness(234, 0 * j, 523, 30 * j);

            Label l5 = new Label();
            l5.Content = "Badges:";
            l5.FontFamily = new FontFamily("Power Red and Green");
            l5.FontSize = 24;
            l5.Width = 157;
            l5.Height = 38;
            l5.Margin = new Thickness(625, 0 * j, 0, 30 * j);

            Label l6 = new Label
            {
                Content = t.numOfBadges,
                FontFamily = new FontFamily("Power Red and Green"),
                FontSize = 24,
                Margin = new Thickness(710, 0 * j, 0, 30 * j)
            };

            BitmapImage pokeIcon = new BitmapImage(new Uri("pack://application:,,,/resources/qblock.jpg", UriKind.Absolute));

            Image i1 = new Image
            {
                Name = "P1",
                Margin = new Thickness(218, 30 * j, 529, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            Image i2 = new Image
            {
                Name = "P2",
                Margin = new Thickness(264, 30 * j, 483, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            Image i3 = new Image
            {
                Name = "P3",
                Margin = new Thickness(304, 30 * j, 437, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            Image i4 = new Image
            {
                Name = "P4",
                Margin = new Thickness(347, 30 * j, 391, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            Image i5 = new Image
            {
                Name = "P5",
                Margin = new Thickness(392, 30 * j, 345, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            Image i6 = new Image
            {
                Name = "P6",
                Margin = new Thickness(437, 30 * j, 299, 3 * j),
                Width = 35,
                Height = 35,
                Source = pokeIcon
            };

            if (i == 0)
            {
                selTraWinGrid.Children.Remove(NoTFound);
            }

            selectTrainerWin.Height = selectTrainerWin.Height + 70;
            selTraWinGrid.Height += 70;

            //backButtons.Add(new Button());
            //backGrids.Add(new Grid());

            MessageBox.Show(backButtons.Capacity.ToString());
            MessageBox.Show(i.ToString());
            MessageBox.Show(backButtons[i].ToString());

            backButtons[i].Width = 784;
            backButtons[i].Height = 70;
            backButtons[i].Margin = new Thickness(0, 0, 0, distanceMod);

            if (i == 0)
                distanceMod = 70;

            backButtons[i].Content = backGrids[i];

            backGrids[i].Children.Add(l1);
            backGrids[i].Children.Add(l2);
            backGrids[i].Children.Add(l3);
            backGrids[i].Children.Add(l4);
            backGrids[i].Children.Add(l5);
            backGrids[i].Children.Add(l6);
            backGrids[i].Children.Add(i1);
            backGrids[i].Children.Add(i2);
            backGrids[i].Children.Add(i3);
            backGrids[i].Children.Add(i4);
            backGrids[i].Children.Add(i5);
            backGrids[i].Children.Add(i6);

            backGrids[i].UpdateLayout();




            //selTraGrid.Children.Add(l1);
            //selTraGrid.Children.Add(l2);
            //selTraGrid.Children.Add(l3);
            //selTraGrid.Children.Add(l4);
            //selTraGrid.Children.Add(l5);
            //selTraGrid.Children.Add(l6);
            //selTraGrid.Children.Add(i1);
            //selTraGrid.Children.Add(i2);
            //selTraGrid.Children.Add(i3);
            //selTraGrid.Children.Add(i4);
            //selTraGrid.Children.Add(i5);
            //selTraGrid.Children.Add(i6);

            //selTraGrid.UpdateLayout();

            //selTraGrid.RowDefinitions.Add(newRow);




        }
    }
}