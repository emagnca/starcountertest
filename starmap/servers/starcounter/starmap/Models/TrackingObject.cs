using System;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class TrackingObject
    {
        public string name;
        public TrackingGroup group;
        public Boolean isConnected;
        public long currentLatitude;
        public long currentLongitude;
        public DateTime lastUpdate;
    }
}
