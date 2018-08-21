using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string @Class { get; set; }
        public double Experience { get; set; }
    }

    public class Entry
    {
        public int Rank { get; set; }
        public bool Dead { get; set; }
        public Character Character { get; set; }
    }

    public class PlayerDataRootObject
    {
        public List<Entry> Entries { get; set; }
    }
}
