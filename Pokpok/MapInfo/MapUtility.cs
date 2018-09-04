using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Pokpok.MapInfo
{
    class MapUtility
    {
        // Create default maps if necessary
        public static void createDefaultMaps()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;

            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\mapdata");

            if (!dir.Exists)
            {
                Directory.CreateDirectory(dir.ToString());
            }

            Map kanto = new Map("Kanto", runningPath + "\\mapdata\\kanto.txt", String.Format("{0}resources\\kanto.xml", Path.GetFullPath(Path.Combine(runningPath, @"..\..\"))));

            if (!File.Exists(kanto.filePath))
            {
                serializeMapData(kanto);
            }


            //Map johto = new Map("Johto", runningPath + "\\mapdata\\johto.txt");
            FileInfo jFile = new FileInfo(runningPath + "\\mapdata\\johto.txt");
            FileInfo hFile = new FileInfo(runningPath + "\\mapdata\\hoenn.txt");
            FileInfo sFile = new FileInfo(runningPath + "\\mapdata\\sinnoh.txt");
            FileInfo uFile = new FileInfo(runningPath + "\\mapdata\\unova.txt");
            FileInfo klFile = new FileInfo(runningPath + "\\mapdata\\kalos.txt");
            FileInfo aFile = new FileInfo(runningPath + "\\mapdata\\unova.txt");


        }

        // Load maps saved in mapdata folder
        public static List<Map> loadAllMaps()
        {
            List<Map> maps = new List<Map>();
            string[] mapDatas = new string[3];

            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\mapdata");

            if (!dir.Exists)
            {
                Directory.CreateDirectory(dir.ToString());
            }

            // Run through files in mapdata directory, creating, setting, and adding a new map object
            foreach (string s in Directory.GetFiles(dir.ToString()))
            {
                Map m = new Map();
                mapDatas = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                m.name = mapDatas[0].Substring(6);
                m.imagePath = mapDatas[1].Substring(9);
                m.playersLoc = mapDatas[2].Substring(11);

                maps.Add(m);
            }

            return maps;
        }

        public static void serializeMapData(Map map)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Map));

            using (StreamWriter sw = new StreamWriter(map.filePath))
            {
                serializer.Serialize(sw, map);
            }
        }
    }
}
