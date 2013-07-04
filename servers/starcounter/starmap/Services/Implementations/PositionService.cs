using starmap.Services.Interfaces;
using starmap.Models;
using Starcounter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace starmap.Services.Implementations
{
    public class PositionService : IPositionService
    {

        public const int HTTP_OK = 200;
        public const int HTTP_BAD_REQUEST = 400;
        public const int HTTP_NOT_FOUND = 404;
        public const int HTTP_CONFLICT = 409;

        public int updatePostion(PositionMsg position)
        {
            int httpReturnCode = HTTP_OK;

            Db.Transaction(() =>
            {
                string name = position.Name;
                TrackingObject t = Db.SQL("SELECT * FROM TrackingObject T WHERE T.Name=?", 
                                            position.Name).First;

                if (t == null || t.group == null) httpReturnCode = HTTP_NOT_FOUND;
                else
                {
                    new Position()
                    {
                        trackingObject = t,
                        latitude = position.Latitude,
                        longitude = position.Longitude,
                        timestamp = DateTime.Now
                    };

                    t.group.numberOfUpdates++;
                }
             });

            return httpReturnCode;
        }

        public int register(UserMsg user)
        {
            int httpReturnCode = HTTP_OK;

            Db.Transaction(() =>
            {
               TrackingObject t = Db.SQL<TrackingObject>("SELECT * FROM TrackingObject T WHERE T.Name=?", user.Name).First;   
               TrackingGroup g = Db.SQL<TrackingGroup>("SELECT * FROM TrackingGroup WHERE Name=?", user.Group).First;

               if (t != null) httpReturnCode = HTTP_CONFLICT;
               else if (!t.isConnected) httpReturnCode = HTTP_BAD_REQUEST;
               else
               {
                   if (g == null)
                   {
                       g = new TrackingGroup()
                       {
                           name = user.Group,
                           numberOfCurrentUsers = 0,
                           numberOfUpdates = 0
                       };
                   }

                   t = new TrackingObject()
                   {
                       name = user.Name,
                       isConnected = true,
                       lastUpdate = DateTime.Now,
                       group = g
                   };

                   g.numberOfCurrentUsers++;
                   g.numberOfUpdates++;
               }
            });

            return httpReturnCode;
        }

        public int deregister(UserMsg user)
        {
            TrackingObject t = Db.SQL<TrackingObject>("SELECT * FROM TrackingObject T WHERE T.Name=?", user.Name).First;
            TrackingGroup g = Db.SQL<TrackingGroup>("SELECT * FROM TrackingGroup WHERE Name=?", user.Group).First;

            if (t != null)
            {
                t.isConnected = false;
                g.numberOfCurrentUsers--;
            }

            return HTTP_OK;
        }

        public IEnumerable getActiveUsersForGroup(string group)
        {
            TrackingGroup g = Db.SQL<TrackingGroup>("SELECT * FROM TrackingGroup WHERE Name=?", group).First;
            return g.activeUsers;
        }

    }
}
