using starmap.Services.Interfaces;

namespace starmap.Services.Implementations
{
    public class PositionServiceLoadTest : IPositionService
    {
        public int  updatePostion(PositionMsg position)
        {
            System.Console.WriteLine("Tracking object: " + position.Name);
            return 0;
        }
    }
}