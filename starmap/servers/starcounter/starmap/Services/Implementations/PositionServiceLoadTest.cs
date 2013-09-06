using Starcounter;
using starmap.Services.Interfaces;
using starmap.Models;
using System.Collections;

namespace starmap.Services.Implementations
{
    public class PositionServiceLoadTest : IPositionService
    {
        IPositionService delegateService = new PositionService();

        const int LOOPS = 100;

        public int updatePostion(PositionMsg position)
        {
            int returnCode = 200;

            for(int i = 0; i < LOOPS; i++)
            {
                returnCode = delegateService.updatePostion(position);
            }

            return returnCode;
        }

        public int register(UserMsg user)
        {
            return delegateService.register(user);
        }

        public int deregister(UserMsg user)
        {
            return delegateService.deregister(user);
        }

        public PositionMsg getCurrentPosition(UserMsg user)
        {
            return delegateService.getCurrentPosition(user);
        }

        public IEnumerable getActiveUsersForGroup(string group)
        {
            return delegateService.getActiveUsersForGroup(group);
        }
    }
}