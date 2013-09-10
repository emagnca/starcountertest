using System;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class PositionXY
    {
        public TrackingObject trackingObject;
        public long latitude;
        public long longitude;
        public DateTime timestamp;

    }
}
