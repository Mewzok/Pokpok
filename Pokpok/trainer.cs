using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Pokpok
{
    public class trainer
    {
        public string name { set; get; }
        public string tClass { set; get; }
        public int money { set; get; }
        public int numOfBadges { set; get; }
        public List<kantoBadges> KBadges { get; set; } = new List<kantoBadges>();
        public List<kantoBadges> JBadges { get; set; } = new List<kantoBadges>();
        public List<kantoBadges> HBadges { get; set; } = new List<kantoBadges>();
        public List<kantoBadges> SBadges { get; set; } = new List<kantoBadges>();
        public List<kantoBadges> UBadges { get; set; } = new List<kantoBadges>();
        public List<kantoBadges> KLBadges { get; set; } = new List<kantoBadges>();

        public string curParty { set; get; }

        public string inBox { set; get; }
    

        public void createTrainer(trainer t, string nm, string tClss)
        {
            //trainer t = new trainer();
            NumOfBadges b = new NumOfBadges();

            t.name = nm;
            t.tClass = tClss;
            t.money = 0;
            b.setNumOfBadges(t);
            t.numOfBadges = b.getNumOfBadges();
            t.curParty = "";
            t.inBox = "";

            // serialize new trainer's info
            Save(t);
        }

        public void modifyTrainer()
        {

        }

        public trainer loadTrainer(String ts)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves");
            FileInfo file = new FileInfo(ts);

            XmlSerializer deserializer = new XmlSerializer(typeof(trainer));
            TextReader reader = new StreamReader(file.ToString());
            object obj = deserializer.Deserialize(reader);
            return (trainer)obj;
        }


        // Save trainer info
        private void Save(trainer t)
        {
            trainercreator tc = new trainercreator();
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves");
            FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\trainersaves\\" + t.name + ".xml");

            XmlSerializer x = new XmlSerializer(t.GetType());

            if(!Directory.Exists(dir.ToString()))
            {
                Directory.CreateDirectory(dir.ToString());
            }
            if (!File.Exists(file.ToString()))
            {
                // Serialize
                using (TextWriter tw = new StreamWriter(file.ToString()))
                {
                    x.Serialize(tw, t);
                }

                MessageBox.Show("Trainer created successfully.");

            } else
            {
                var result = MessageBox.Show(t.name + " already exists. Are you sure you want to overwrite this save?", "Warning", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    using (TextWriter tw = new StreamWriter(file.ToString()))
                    {
                        x.Serialize(tw, t);
                    }
                    MessageBox.Show("Trainer created successfully.");
                }
                else
                {

                }
            }
        }
    }
}
