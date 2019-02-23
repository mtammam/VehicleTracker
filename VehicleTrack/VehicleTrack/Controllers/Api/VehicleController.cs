using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleTrack.Hubs;
using VehicleTrack.Models;

namespace VehicleTrack.Controllers.Api
{
    public class VehicleController : ApiController
    {
        ApplicationDbContext _context;
        public VehicleController()
        {
            _context = new ApplicationDbContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //    _context.Dispose();
        //}
        public void Post(Vehicle vehicle)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<vehicleHub>();
            context.Clients.All.vhehicleStatusMessage(vehicle.Id, vehicle.Status,vehicle.ApplicationUserID);
           
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles(string userId)
        {
            var Vehicles = _context.Vehicle;//.Where(e => e.ApplicationUserID.ToLower() == userId.ToLower());
            return Vehicles;
           
        }
    }
}
