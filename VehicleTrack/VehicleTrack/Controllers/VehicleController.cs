using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTrack.Models;
using Microsoft.AspNet.Identity;
using VehicleTrack.Extentions;

namespace VehicleTrack.Controllers
{
    public class VehicleController : Controller
    {

        ApplicationDbContext _context;
        public VehicleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewVehicle(Vehicle vehicle)
        {

            vehicle.ApplicationUserID = User.Identity.GetUserId();
            // vehicle.VIN= Guid.NewGuid().ToString(); 
            if (ModelState.IsValid)
            {
                _context.Vehicle.Add(vehicle);
                _context.SaveChanges();
            }

            return View();
        }

        public ActionResult Vehicles()
        {
            ViewBag.Name = User.Identity.GetFullName();
            var userId = User.Identity.GetUserId();
            var vehicles = _context.Vehicle;//.Include(u=>u.ApplicationUser).Where(e => e.ApplicationUserID ==userId );

            return View(vehicles);
        }

        public ActionResult RuningVehicles()
        {
            ViewBag.Name = User.Identity.GetFullName();
            var userId = User.Identity.GetUserId();
            var vehicles = _context.Vehicle;//.Include(u=>u.ApplicationUser).Where(e => e.ApplicationUserID ==userId );

            return View(vehicles);
        }


        public ActionResult VheicleList()
        { return View(); } 
    }
}