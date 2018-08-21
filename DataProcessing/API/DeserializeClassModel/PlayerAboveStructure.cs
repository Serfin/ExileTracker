using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.DeserializeClassModel
{
    public class Character
    {
        public string @Class { get; set; }
    }

    public class Entry
    {
        public Character Character { get; set; }
    }

    public class PlayerAboveRootObject
    {
        public List<Entry> Entries { get; set; }
    }
}
