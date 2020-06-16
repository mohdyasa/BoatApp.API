using BoatManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoatManagementSystem.DAL.Persistence
{
    public class BoatManagementDBContext: DbContext
    {
        public BoatManagementDBContext(DbContextOptions<BoatManagementDBContext> options) : base(options) { }
        public DbSet<Boat_Info> Boat_Info { get; set; }
        public DbSet<Boat_RentInfo> Boat_RentInfo { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
