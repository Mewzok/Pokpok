using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokpok
{
    class SaveClass
    {
        public List<trainer> activeT = new List<trainer>();
        public List<trainer> passiveT = new List<trainer>();

        public static void saveCurTrainers(List<trainer> aT, List<trainer> pT)
        {
            SaveClass sc = new SaveClass
            {
                activeT = aT,
                passiveT = pT
            };

        }

        public static List<trainer> loadCurActTrainers()
        {
            SaveClass sc = new SaveClass();
            return sc.activeT;
        }

        public static List<trainer> loadCurPasTrainers()
        {
            SaveClass sc = new SaveClass();
            return sc.passiveT;
        }
    }
}
