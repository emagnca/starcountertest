using starmap.Services.Interfaces;
using starmap.Services.Implementations;
using starmap.Controllers;

class Start
{

    static IPositionService service = new PositionServiceLoadTest();
    static PositionController controller = new PositionController(service);

    static void Main()
    {
        controller.SetupUrls();
    }
}
