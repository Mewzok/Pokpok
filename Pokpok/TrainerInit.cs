using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pokpok
{
    class TrainerInit
    {
        public List<trainer> activeTrainers { get; set; } = new List<trainer>();
        public List<trainer> passiveTrainers { get; set; } = new List<trainer>();

        public void loadPassiveTrainers()
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves");
            string[] filePaths = Directory.GetFiles(dir.ToString(), "*.xml", SearchOption.TopDirectoryOnly);
            trainer t = new trainer();
            int i = 0;

            foreach (string s in filePaths)
            {
                t = t.loadTrainer(filePaths[i]);
                passiveTrainers.Add(t);
                i++;
            }
        }

        public void recieveTrainerData(List<trainer> aTData, List<trainer> aPData)
        {
            activeTrainers = aTData;
            passiveTrainers = aPData;
        }
    }
}
