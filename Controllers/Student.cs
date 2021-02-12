using IUBAT_Bus_Management_System.Data;
using IUBAT_Bus_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        public Student(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [Authorize(Roles = "Student")]
        public IActionResult GiveFeedback()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        [HttpPost]
        public async Task<IActionResult> GiveFeedback(FeedBack FB)
        {
            FB.time = DateTime.Now;
            _db.FeedBack.Add(FB);
            await _db.SaveChangesAsync();
            return RedirectToAction("ShowBusList","Admin");
        }
    }
}
