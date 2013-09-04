using System.Collections;
using Starcounter;

namespace starmap.Models
{
    [Database]
    public class TrackingGroup
    {
        public string name;
        public long numberOfCurrentUsers;
        public long numberOfUpdates;
        public bool isActive { get { return numberOfCurrentUsers > 0; } }
        public IEnumerable activeUsers { get { return Db.SQL<TrackingGroup>("SELECT T FROM TrackingObject T WHERE T.isConnected=true AND T.Group.Name=?", this); } } 
    }
}
