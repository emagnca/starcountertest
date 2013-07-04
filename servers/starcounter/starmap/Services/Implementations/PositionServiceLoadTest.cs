using starmap.Services.Interfaces;
using System.Collections;

namespace starmap.Services.Implementations
{
    public class PositionServiceLoadTest : IPositionService
    {
        IPositionService delegateService = new PositionService();

        const int LOOPS = 2;

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
            int returnCode = 200;

            for (int i = 0; i < LOOPS; i++)
            {
                returnCode = delegateService.register(user);
            }

            return returnCode;
        }

        public int deregister(UserMsg user)
        {
            int returnCode = 200;

            for (int i = 0; i < LOOPS; i++)
            {
                returnCode = delegateService.deregister(user);
            }

            return returnCode;
        }

        public IEnumerable getPositionsForGroup(string group)
        {
            return delegateService.getPositionsForGroup(group);
        }
    }
}