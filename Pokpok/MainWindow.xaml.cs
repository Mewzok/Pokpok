﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokpok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainConsole_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string allText = new TextRange(MainConsole.Document.ContentStart, MainConsole.Document.ContentEnd).Text;
                string mainText = "";

                string[] lines = (allText.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
                mainText = lines[lines.Length-2];

                readConsoleInput(mainText);
            }
        }

        // read console input and act
        private void readConsoleInput(string mT)
        {
            string mainText = mT;

            // basic help information and all available commands
            #region available commands
            if (mainText.ToLower().Trim() == "/help".ToString().ToLower().Trim())
            {
                MainConsole.AppendText("\nList of available commands:");
                MainConsole.AppendText("\n/help ability {ability name}");
                MainConsole.CaretPosition = MainConsole.CaretPosition.DocumentEnd;
            }
            #endregion

            // help for all abilities
            #region all abilities
            else if (mainText.ToLower().Trim() == "/help ability adaptability".ToString().ToLower().Trim())
            {
                //adaptabilityInfo();
            }
            #endregion

            // unrecognized command information
            else
            {
                MainConsole.AppendText("\nUnrecognized command. Use /help to see a list of available commands.");
                MainConsole.CaretPosition = MainConsole.CaretPosition.DocumentEnd;
            }
        }

        private void wBatButton_Click(object sender, RoutedEventArgs e)
        {
            wildBattleWindow win2 = new wildBattleWindow();
            win2.Show();
            this.Hide();
        }

        private void cTrainButton_Click(object sender, RoutedEventArgs e)
        {
            trainercreator trainerCreatorWin = new trainercreator();
            trainerCreatorWin.Show();
        }

        private void cSetChangePartyButton_Click(object sender, RoutedEventArgs e)
        {
            TrainerPartyManager trainerPartyManWin = new TrainerPartyManager();
            trainerPartyManWin.Show();
        }
    }
}
