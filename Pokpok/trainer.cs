using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pokpok
{
    class trainer
    {
        string name = "";
        string tClass = "";
        int money = 0;
        kantoBadges? kBadges = null;
        johtoBadges? jBadges = null;
        hoennBadges? hBadges = null;
        sinnohBadges? sBadges = null;
        unovaBadges? uBadges = null;
        kalosBadges? klBadges = null;

        string curParty = "";



        string inBox = "";

    

        public void createTrainer(string nm, string tClss)
        {
            trainer t = new trainer();

            t.name = nm;
            t.tClass = tClss;

            // serialize new trainer's info
            Save(t);
        }

        public void modifyTrainer()
        {

        }

        public void loadTrainer()
        {

        }


        // Save trainer info
        private void Save(trainer t)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves");
            FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves\\" + t.name + ".xml");

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(t.GetType());

            if (!File.Exists(file.ToString()))
            {
                // Serialize
                using (TextWriter tw = new StreamWriter(file.ToString()))
                {
                    x.Serialize(tw, t);
                }
            } else
            {
                var result = MessageBox.Show(t.name + " already exists. Are you sure you want to overwrite this save?", "Warning", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    using (TextWriter tw = new StreamWriter(file.ToString()))
                    {
                        x.Serialize(tw, t);
                    }
                }
                else { }
            }
            



        }
    }
}
