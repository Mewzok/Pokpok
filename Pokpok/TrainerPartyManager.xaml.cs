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
    /// Interaction logic for TrainerPartManager.xaml
    /// </summary>
    public partial class TrainerPartyManager : Window
    {
        public TrainerPartyManager()
        {
            InitializeComponent();
            ChangeGridLineColors();
        }

        private void ChangeGridLineColors()
        {
            var T = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer," + " PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            var GLR = Activator.CreateInstance(T);
            GLR.GetType().GetField("s_oddDashPen", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Black, 1.0));
            GLR.GetType().GetField("s_evenDashPen", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Black, 1.0));

            tpmGrid.ShowGridLines = true;
        }
    }
}
