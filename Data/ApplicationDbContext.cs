using IUBAT_Bus_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IUBAT_Bus_Management_System.ViewModel;

namespace IUBAT_Bus_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BusDetails> BusDetails { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<IUBAT_Bus_Management_System.ViewModel.EBus> EBus { get; set; }
        public DbSet<IUBAT_Bus_Management_System.ViewModel.RoleViewModel> RoleViewModel { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
    }
}
