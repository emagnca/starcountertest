using System;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class Group
    {
        public string name;
        public long numberOfUpdates;
    }
}
