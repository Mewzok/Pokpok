using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Pokpok
{
    class TrainerInit
    {
        public static TrainerInit tI = new TrainerInit();
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
                if (t.active == false)
                    passiveTrainers.Add(t);
                else
                    activeTrainers.Add(t);

                i++;
            }
        }

        public static void recieveTrainerData(List<trainer> aTData, List<trainer> aPData)
        {
            tI.activeTrainers = aTData;
            tI.passiveTrainers = aPData;

            foreach (trainer t in tI.activeTrainers)
                MessageBox.Show("TrainerInit: " + t.name);
        }
    }
}
