using System;
using Starcounter;
using starmap.Services.Interfaces;

namespace starmap.Controllers
{
    public class PositionController
    {
        private const int SERVER_PORT = 8282;

        private IPositionService service;

        public PositionController(IPositionService service)
        {
            this.service = service;
        }

        public void SetupUrls()
        {
             Handle.POST(SERVER_PORT, "/position", (PositionMsg message) => 
             {
                 return service.updatePostion(message);
             });
                         
            Handle.POST(SERVER_PORT, "/register", (string group) =>
            {
                return 200;
            });
        }
            
    }
}
