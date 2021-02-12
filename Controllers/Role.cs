using IUBAT_Bus_Management_System.Data;
using IUBAT_Bus_Management_System.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUBAT_Bus_Management_System.Controllers
{
    public class Role : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Role(ApplicationDbContext db, ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _logger = logger;
            _roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel rolee)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(rolee.RoleName));
            return RedirectToAction(nameof(Create));
        }
    }
}
