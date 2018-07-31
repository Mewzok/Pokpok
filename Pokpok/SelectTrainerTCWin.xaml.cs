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
        int distanceMod = 0;
        int distanceMod2 = 0;
        int n = 0;
        int m = 0;

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


            List<Button> backButtons = new List<Button>();
            List<Grid> backGrids = new List<Grid>();
            List<Label> backLabels = new List<Label>();
            List<Image> backImages = new List<Image>();

            foreach (string s in filePaths)
            {
                t = t.loadTrainer(filePaths[i]);
                backButtons.Add(new Button());
                backGrids.Add(new Grid());

                for (int l = 0; l < 8; l++)
                {
                    backLabels.Add(new Label());
                    backImages.Add(new Image());

                }
                createNewRow(t, filePaths, i, backButtons, backGrids, backLabels, backImages);
                i++;
            }

            i = 0;
            foreach (Button b in backButtons)
            {
                int j = i + 1;
                backButtons[i].Margin = new Thickness(0, distanceMod, 0, 70 * backButtons.Count - distanceMod2 - 70);

                selTraWinGrid.Children.Add(backButtons[i]);

                if (i == 0)
                {
                    distanceMod = 70;
                    distanceMod2 = distanceMod;
                }
                else
                {
                    distanceMod = 70 * j;
                    distanceMod2 = distanceMod;
                }

                i++;
            }
            //backButtons[3].Margin = new Thickness(0, 280, 0, )
        }

        private void createNewRow(trainer t, string[] filePaths, int i, List<Button> backButtons, List<Grid> backGrids, List<Label> backLabels, List<Image> backImages)
        {
            #region Labels
            int j = i + 1;

            backLabels[n].Content = t.name;
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(0, 0, 0, 0);
            n++;

            backLabels[n].Content = t.tClass;
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(0, 30, 0, 0);
            n++;

            backLabels[n].Content = "$";
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(218, 0, 539, 30);
            n++;

            backLabels[n].Content = t.money;
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(234, 0, 400, 30);
            backLabels[n].Width = 200;
            n++;

            backLabels[n].Content = "Seen:";
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(530, 0, 0, 30);
            n++;

            backLabels[n].Content = t.seen;
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(585, 0, 0, 30);
            n++;

            backLabels[n].Content = "Badges:";
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Width = 157;
            backLabels[n].Height = 38;
            backLabels[n].Margin = new Thickness(650, 0, 0, 30);
            n++;

            backLabels[n].Content = t.numOfBadges;
            backLabels[n].FontFamily = new FontFamily("Power Red and Green");
            backLabels[n].FontSize = 24;
            backLabels[n].Margin = new Thickness(730, 0, 0, 30);
            n++;
            #endregion

            #region Images
            BitmapImage pokeIcon = new BitmapImage(new Uri("pack://application:,,,/resources/qblock.jpg", UriKind.Absolute));

            backImages[m].Name = "P1";
            backImages[m].Margin = new Thickness(218, 30, 525, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;

            backImages[m].Name = "P2";
            backImages[m].Margin = new Thickness(264, 30, 479, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;

            backImages[m].Name = "P3";
            backImages[m].Margin = new Thickness(310, 30, 433, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;

            backImages[m].Name = "P4";
            backImages[m].Margin = new Thickness(356, 30, 387, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;

            backImages[m].Name = "P5";
            backImages[m].Margin = new Thickness(402, 30, 341, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;

            backImages[m].Name = "P6";
            backImages[m].Margin = new Thickness(448, 30, 295, 3);
            backImages[m].Width = 35;
            backImages[m].Height = 35;
            backImages[m].Source = pokeIcon;
            m++;
            #endregion

            if (i == 0)
            {
                selTraWinGrid.Children.Remove(NoTFound);
            }

            if (i >= 1)
            {
                selectTrainerWin.Height = selectTrainerWin.Height + 70;
                selTraWinGrid.Height += 70;
            }

            backButtons[i].Width = 784;
            backButtons[i].Height = 70;

            backButtons[i].Background = Brushes.SlateGray;

            backButtons[i].Content = backGrids[i];

            // Reset counters for looping to add them to the grids
            n -= 8;
            m -= 6;

            // Loop through every label, adding them to the grid
            while (n < 8 * j)
            {
                backGrids[i].Children.Add(backLabels[n]);
                n++;
            }

            // Loop through every image, adding them to the grid
            while (m < 6 * j)
            {
                backGrids[i].Children.Add(backImages[m]);
                m++;
            }

            backGrids[i].UpdateLayout();
        }
    }
}