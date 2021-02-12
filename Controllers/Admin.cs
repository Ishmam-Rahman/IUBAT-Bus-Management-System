using IUBAT_Bus_Management_System.Data;
using IUBAT_Bus_Management_System.Models;
using IUBAT_Bus_Management_System.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.Controllers
{
    public class Admin : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        public Admin(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        //-----------------------------------------------Bus Manipulate Section--------------------------------------------------//

        [Authorize(Roles = "Admin, Student")]
        public IActionResult ShowBusList()
        {
            return View(_db.BusDetails.ToList());
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AddBus()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBus(BusDetails busdetails)
        {
            if (ModelState.IsValid)
            {
                _db.BusDetails.Add(busdetails);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(ShowBusList));
            }
            return View(busdetails);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditBus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var busdetal = _db.BusDetails.Find(id);
            var Busdetails = new EBus
            {
                Id = busdetal.Id,
                BusName = busdetal.BusName,
                BusNameB = busdetal.BusName,
                DriverName = busdetal.DriverName,
                DriverPhone = busdetal.DriverPhone,
                DeparterTime = busdetal.DeparterTime,
            };
            return View(Busdetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBus(EBus busdetal)
        {
            if (ModelState.IsValid)
            {
                var busDetails = new BusDetails
                {
                    Id = busdetal.Id,
                    BusName = busdetal.BusName,
                    DriverName = busdetal.DriverName,
                    DriverPhone = busdetal.DriverPhone,
                    DeparterTime = busdetal.DeparterTime,
                };
                _db.BusDetails.Update(busDetails);
                var tergetRoute = _db.Route.Where(c=>c.BusName == busdetal.BusNameB);
                foreach(Route item in tergetRoute)
                {
                    item.BusName = busDetails.BusName;
                    _db.Route.Update(item);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(ShowBusList));
            }
            return View(busdetal);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busdetails = _db.BusDetails.Find(id);
            if (busdetails == null)
            {
                return RedirectToAction("ShowBusList");
            }
            return View(busdetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteBus(int? id, BusDetails busDetails)
        {
            var bus = _db.BusDetails.Find(id);
            _db.BusDetails.Remove(bus);
            _db.Route.RemoveRange(_db.Route.Where(c => c.BusName == bus.BusName));
            await _db.SaveChangesAsync();
            return RedirectToAction("ShowBusList");
        }


        //-------------------------Route Manipulate Section----------------------------------------------//
        [Authorize(Roles = "Admin, Student")]
        public IActionResult ShowRoute(string busname)
        {
            var route_list = _db.Route.Where(c => c.BusName == busname);
            return View(route_list.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddRoute()
        {
            ViewData["BusId"] = new SelectList(_db.BusDetails.ToList(),"BusName", "BusName");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoute(Route route)
        {
            if (ModelState.IsValid)
            {
                _db.Route.Add(route);
                await _db.SaveChangesAsync();
                return RedirectToAction("ShowRoute", new { @BusName = route.BusName });
            }
            return RedirectToAction(nameof(AddRoute));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRoute(int? id)
        {
            Console.WriteLine("id = " + id);
            if (id == null)
            {
                return NotFound();
            }

            var routeedetails = _db.Route.Find(id);
            if (routeedetails == null)
            {
                return RedirectToAction("ShowRoute", new { @BusName = routeedetails.BusName });
            }
            return View(routeedetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoute(int? id, Route employeeDetails)
        {
            var employe = _db.Route.Find(id);
            _db.Route.Remove(employe);
            await _db.SaveChangesAsync();
            return RedirectToAction("ShowRoute", new { @BusName = employe.BusName });
        }
        //-----------------------------------------Others---------------------------------//

        [Authorize(Roles = "Admin, Student")]
        public IActionResult busbyplace(string Place)
        {
            if(Place == null)
            {
                return View(_db.Route.ToList());
            }
            var buslist = _db.Route.Where(c => c.RouteName == Place);
            return View(buslist.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowFeedBack()
        {
            return View(_db.FeedBack.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFB(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busdetails = _db.FeedBack.Find(id);
            if (busdetails == null)
            {
                return RedirectToAction("ShowFeedBack");
            }
            return View(busdetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteFB(int? id, FeedBack busDetails)
        {
            var bus = _db.FeedBack.Find(id);
            _db.FeedBack.Remove(bus);
            await _db.SaveChangesAsync();
            return RedirectToAction("ShowBusList");
        }

    }
}
