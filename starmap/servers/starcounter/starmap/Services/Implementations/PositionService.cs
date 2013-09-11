using starmap.Services.Interfaces;
using starmap.Models;
using Starcounter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace starmap.Services.Implementations
{
    public class PositionService : IPositionService
    {
        public const int HTTP_OK = 200;
        public const int HTTP_BAD_REQUEST = 400;
        public const int HTTP_NOT_FOUND = 404;
        public const int HTTP_CONFLICT = 409;
        public const int HTTP_ERROR = 500;
        public const int HTTP_SERVICE_UNAVAILABLE = 503;

        private const string LOG_FILE = @"C:\Users\Magnus Carlhammar\StarCounterTestError.log";

        public int updatePostion(PositionMsg position)
        {
            int httpReturnCode = HTTP_OK;

            try
            {
                Db.Transaction(() =>
                {
                    string name = position.Name;
                    TrackingObject t = (TrackingObject)Db.SQL("SELECT T FROM TrackingObject T WHERE T.Name=?",
                                               position.Name).First;

                    if (t == null || t.group == null) httpReturnCode = HTTP_NOT_FOUND;
                    else
                    {
                        new PositionXY()
                        {
                            trackingObject = t,
                            latitude = position.Latitude,
                            longitude = position.Longitude,
                            timestamp = DateTime.Now
                        };

                        t.currentLatitude = position.Latitude;
                        t.currentLongitude = position.Longitude;
                        t.group.numberOfUpdates++;
                    }
                });
            }
            catch (Exception x)
            {
                handleException(x);
                httpReturnCode = HTTP_SERVICE_UNAVAILABLE;
            }

            return httpReturnCode;
        }

        public int register(UserMsg user)
        {
            int httpReturnCode = HTTP_OK;

            try
            {
                Db.Transaction(() =>
                {
                    TrackingObject t = Db.SQL<TrackingObject>("SELECT T FROM TrackingObject T WHERE T.Name=?", user.Name).First;
                    TrackingGroup g = Db.SQL<TrackingGroup>("SELECT T FROM TrackingGroup T WHERE T.Name=?", user.Group).First;

                    if (t != null)
                    {
                        if (t.isConnected) httpReturnCode = HTTP_CONFLICT;
                        else t.isConnected = true;
                    }
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
            }
            catch (Exception x)
            {
                handleException(x);
                httpReturnCode = HTTP_SERVICE_UNAVAILABLE;
            }

            return httpReturnCode;
        }

        public int deregister(UserMsg user)
        {
            int httpReturnCode = HTTP_OK;
            try
            {
                Db.Transaction(() =>
                {
                    TrackingObject t = Db.SQL<TrackingObject>("SELECT T FROM TrackingObject T WHERE T.Name=?", user.Name).First;
                    TrackingGroup g = Db.SQL<TrackingGroup>("SELECT T FROM TrackingGroup T WHERE T.Name=?", user.Group).First;

                    if (t != null)
                    {
                        t.isConnected = false;
                        g.numberOfCurrentUsers--;
                    }

                    foreach (PositionXY p in Db.SQL<PositionXY>("SELECT P FROM PositionXY P WHERE P.trackingObject.Name=?", user.Name))
                    {
                        p.Delete();
                    }
                });
            }
            catch (Exception x)
            {
                handleException(x);
                httpReturnCode = HTTP_SERVICE_UNAVAILABLE;
            }

            return httpReturnCode;
        }

        public PositionMsg getCurrentPosition(UserMsg user)
        {
            PositionMsg p = new PositionMsg();
            TrackingObject t = Db.SQL<TrackingObject>("SELECT T FROM TrackingObject T WHERE T.Name=?", user.Name).First;

            p.Name = user.Name;
            p.Group = user.Group;
            p.Latitude = t!=null? t.currentLatitude : 0;
            p.Longitude = t!= null? t.currentLongitude : 0;

            return p;
        }

        public int deletePositionsForUser(UserMsg user)
        {
            Db.Transaction(() =>
            {
                foreach (PositionXY p in Db.SQL<PositionXY>("SELECT P FROM PositionXY P WHERE P.trackingObject.Name=?", user.Name))
                {
                    p.Delete();
                }
            });
            return HTTP_OK;
        }

        public IEnumerable getActiveUsersForGroup(string group)
        {
            TrackingGroup g = Db.SQL<TrackingGroup>("SELECT T FROM TrackingGroup T WHERE T.Name=?", group).First;
            return g.activeUsers;
        }

        private void handleException(Exception x)
        {
            using (StreamWriter file = new StreamWriter(LOG_FILE, true))
            {
                file.Write("Exception at " + System.DateTime.Now + ": ");
                file.WriteLine(x.Message);
            }
        }

    }
}
