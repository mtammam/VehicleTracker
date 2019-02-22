using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace VehicleTrack.Hubs
{

    public class vehicleHub : Hub
    {
        public void SendVehicleStatus(int Id, bool Status)
        {
            this.Clients.All.vhehicleStatusMessage(Id,Status);
        }
    }
}