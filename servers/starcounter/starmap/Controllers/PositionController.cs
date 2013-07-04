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
            Handle.GET(SERVER_PORT, "/position", () =>
            {
                return 200;
            });

             Handle.POST(SERVER_PORT, "/position", (PositionMsg message) => 
             {
                 return service.updatePostion(message);
             });
                         
            Handle.POST(SERVER_PORT, "/register", (UserMsg user) =>
            {
                return service.register(user); ;
            });

            Handle.POST(SERVER_PORT, "/deregister", (UserMsg user) =>
            {
                return 200;
            });

        }
            
    }
}
