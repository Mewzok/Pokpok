using System;
using System.Collections.Generic;
using System.IO;

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

        //public static MemoryStream DeepSavePTrainers(List<trainer> pTrainer)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, pTrainer);
        //        ms.Position = 0;

        //        return ms;
        //    }
        //}

        //public static List<trainer> DeepLoadPTrainers(MemoryStream ms)
        //{
        //    List<trainer> t = new List<trainer>();
        //    var formatter = new BinaryFormatter();

        //    return (List<trainer>) formatter.Deserialize(ms);
        //}



        private void loadCurTrainers()
        {
            //activeTrainers = aT2;
        }
    }
}
