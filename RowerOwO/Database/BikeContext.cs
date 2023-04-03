using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;

namespace RowerOwO.Database
{
    public class BikeContext : DbContext
    {
        public DbSet<VehicleItemModel> Vehicles { get; set; }
        public DbSet<VehicleDetailModel> VehicleDetails { get; set; }
        public DbSet<RentModel> Rentals { get; set; }
        public DbSet<RentalPointModel> RentalPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BikeDB");
        }
    }
}
