using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pokpok
{
    /// <summary>
    /// Interaction logic for TrainerPartManager.xaml
    /// </summary>
    public partial class TrainerPartyManager : Window
    {
        public int rowCounter = 3;
        public List<Button> rowButtonList = new List<Button>();
        public List<trainer> pTrainers = new List<trainer>();
        public bool isYes = false;

        public TrainerPartyManager()
        {
            InitializeComponent();
            ChangeGridLineColors();
            addFirstButton();
            AddButtonsToList();
        }

        private void addFirstButton()
        {
            Button b1 = new Button
            {
                Height = 70,
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontFamily = new FontFamily("Power Red and Green"),
                FontSize = 36,
                Content = "Add"
            };

            b1.Click += new RoutedEventHandler(button_Click);

            tpmGrid.Children.Add(b1);
            Grid.SetRow(b1, 0);
            Grid.SetColumn(b1, 0);
        }

        private void ChangeGridLineColors()
        {
            var T = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer," + " PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            var GLR = Activator.CreateInstance(T);
            GLR.GetType().GetField("s_oddDashPen", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Black, 1.0));
            GLR.GetType().GetField("s_evenDashPen", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Black, 1.0));

            tpmGrid.ShowGridLines = true;
        }

        private void AddButtonsToList()
        {
            foreach (Button b in tpmGrid.Children)
            {
                rowButtonList.Add(b);
            }
        }

        #region button events
        //private void Add1_Click(object sender, RoutedEventArgs e)
        //{
        //    TrainerInit ti = new TrainerInit();

        //    ti.loadPassiveTrainers();

        //    rowCounter = 3;

        //    addRow();

        //    SelectTrainerTCWin selTra = new SelectTrainerTCWin(ti);

        //    selTra.Show();


        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TrainerInit ti = new TrainerInit();
            ti.loadPassiveTrainers();

            SelectTrainerTCWin selTra = new SelectTrainerTCWin(ti);

            selTra.Show();
        }

        private void doIfYes()
        {
            addRow();
        }

        public void trainerAdded(bool conf)
        {
            if(conf == true)
            {
                
            }
        }

        private void addRow()
        {
            RowDefinition newRow = new RowDefinition();

            newRow.Height = new GridLength(70);

            tpmGrid.Height = tpmGrid.Height + 70;

            tpmGrid.RowDefinitions.Remove(CCRow);
            tpmGrid.RowDefinitions.Add(newRow);
            //tpmGrid.RowDefinitions.Add(CCRow);
            tpmConfirmButton.SetValue(Grid.RowProperty, 2);
            tpmCancelButton.SetValue(Grid.RowProperty, 2);

            rowCounter++;
        }
        #endregion

        private void loadTrainer()
        {

        }

    }
}


/*
                 <Button Name="Add2" Content="Add" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden" Click="Add2_Click"/>
                <Button Name="Add3" Content="Add" HorizontalAlignment="Left" Grid.Row="2" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden" Click="Add3_Click"/>
                <Button Name="Add4" Content="Add" HorizontalAlignment="Left" Grid.Row="3" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden" Click="Add4_Click"/>
                <Button Name="Add5" Content="Add" HorizontalAlignment="Left" Grid.Row="4" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden" Click="Add5_Click"/>
                <Button Name="Add6" Content="Add" HorizontalAlignment="Left" Grid.Row="5" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden" Click="Add6_Click"/>
                <Button Name="Add7" Content="Add" HorizontalAlignment="Left" Grid.Row="6" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>
                <Button Name="Add8" Content="Add" HorizontalAlignment="Left" Grid.Row="7" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>
                <Button Name="Add9" Content="Add" HorizontalAlignment="Left" Grid.Row="8" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>
                <Button Name="Add10" Content="Add" HorizontalAlignment="Left" Grid.Row="9" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>
                <Button Name="Add11" Content="Add" HorizontalAlignment="Left" Grid.Row="10" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>
                <Button Name="Add12" Content="Add" HorizontalAlignment="Left" Grid.Row="11" VerticalAlignment="Top" Width="100" Height="70" FontFamily="Power Red and Green" FontSize="36" Visibility="Hidden"/>

                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>
                    <RowDefinition Height="60*"/>

    Height="837"

                        <ColumnDefinition Width="25*"/>
                    <ColumnDefinition Width="173*"/>
*/
