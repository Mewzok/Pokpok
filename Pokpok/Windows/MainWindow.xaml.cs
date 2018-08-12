using System;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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
            Thread newWindowThread = new Thread(new ThreadStart(cTrainButton_Action));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void cTrainButton_Action()
        {
            trainercreator trainerCreatorWin = new trainercreator();
            trainerCreatorWin.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void cSetChangePartyButton_Click(object sender, RoutedEventArgs e)
        {
            Thread newWindowThread = new Thread(new ThreadStart(cSetChangePartyButton_Action));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void cSetChangePartyButton_Action()
        {
            TrainerPartyManager trainerPartyManWin = new TrainerPartyManager();
            trainerPartyManWin.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        //private void cSetChangeParty_Action()
        //{

        //    System.Windows.Threading.Dispatcher.Run();
        //}
    }
}
