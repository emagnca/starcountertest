using System;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class TrackingObject
    {
        public string name;
        public Group group;
        public Boolean isConnected;
        public DateTime lastUpdate;
    }
}
