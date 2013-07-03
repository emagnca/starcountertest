using starmap.Services.Interfaces;

namespace starmap.Services.Implementations
{
    public class PositionServiceLoadTest : IPositionService
    {
        public void updatePostion(PositionMsg position)
        {
            System.Console.WriteLine("Tracking object: " + position.Name);
        }
    }
}