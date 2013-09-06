using Starcounter;
using System.Collections;

namespace starmap.Services.Interfaces
{
    public interface IPositionService
    {
        int updatePostion(PositionMsg position);
        int register(UserMsg user);
        int deregister(UserMsg user);
        PositionMsg getCurrentPosition(UserMsg user);
        IEnumerable getActiveUsersForGroup(string group);
    }
}
