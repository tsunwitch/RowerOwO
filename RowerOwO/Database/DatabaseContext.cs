using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;
using RowerOwO.ViewModels;

namespace RowerOwO.Database
{
    public class DatabaseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<RentalPointModel> RentalPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BikeDB");
        }
	}
}
