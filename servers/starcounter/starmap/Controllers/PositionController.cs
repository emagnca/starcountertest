using System;
using System.Collections;
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
                         
            Handle.POST(SERVER_PORT, "/register", (UserMsg user) =>
            {
                return service.register(user); ;
            });

            Handle.POST(SERVER_PORT, "/deregister", (UserMsg user) =>
            {
                return service.deregister(user);
            });

            Handle.GET(SERVER_PORT, "/position", (string group) =>
            {
                // TODO: HOW?
                var json = new ActiveUsersMsg();
                IEnumerable e = service.getActiveUsersForGroup(group);
                // json.Data = e;
                return json;
            });
        }
            
    }
}
