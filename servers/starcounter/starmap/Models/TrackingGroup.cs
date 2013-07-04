using System;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class TrackingGroup
    {
        public string name;
        public long numberOfCurrentUsers;
        public long numberOfUpdates;
    }
}
