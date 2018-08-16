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
        public string Id { get; set; }
        public double Experience { get; set; }
    }

    public class Entry
    {
        public int Rank { get; set; }
        public bool Dead { get; set; }
        public bool Online { get; set; }
        public Character Character { get; set; }
    }

    public class RootObject
    {
        public DateTime Cached_since { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
