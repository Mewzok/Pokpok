using System;
using System.Collections.Generic;
using System.IO;

namespace Pokpok.MapInfo
{
    class Map
    {
        public string name { get; set; }
        public string filePath { get; set; }
        public string imagePath { get; set; }
        public string activePlayers { get; set; }
        public string playersLoc { get; set; }

        public Map()
        {

        }

        public Map(string name, string filePath, string imagePath)
        {
            this.name = name;
            this.filePath = filePath;
            this.imagePath = imagePath;
            activePlayers = "";
            playersLoc = "";
        }
    }
}
