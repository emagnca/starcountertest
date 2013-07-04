using starmap.Services.Interfaces;
using starmap.Models;
using Starcounter;

namespace starmap.Services.Implementations
{
    public class PositionService : IPositionService
    {
        public int updatePostion(PositionMsg position)
        {
            int httpReturnCode = 200;

            Db.Transaction(() =>
            {
                string name = position.Name;
                TrackingObject t = Db.SQL("SELECT T FROM TrackingObject WHERE TrackingObject.Name=?", 
                                          position.Name).First;
                if (t == null) httpReturnCode = 400;
             });

            return httpReturnCode;
        }
    }
}
