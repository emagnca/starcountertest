using System;
using Starcounter;

namespace starmap.Model
{
    [Database]
    public class Position
    {
        public TrackingObject trackingObject;
        public long latitude;
        public long longitude;
        public DateTime timestamp;
    }
}
