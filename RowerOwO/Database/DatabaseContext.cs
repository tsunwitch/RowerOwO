using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;
using RowerOwO.ViewModels;

namespace RowerOwO.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<RentalPointModel> RentalPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BikeDB");
        }

        public DbSet<RowerOwO.ViewModels.VehicleEditViewModel>? VehicleEditViewModel { get; set; }

        public DbSet<RowerOwO.ViewModels.RentalPointListViewModel>? RentalPointListViewModel { get; set; }

        public DbSet<RowerOwO.ViewModels.VehicleCreateViewModel>? VehicleCreateViewModel { get; set; }

        public DbSet<RowerOwO.ViewModels.RentalPointCreateViewModel>? RentalPointCreateViewModel { get; set; }

        public DbSet<RowerOwO.ViewModels.RentalPointEditViewModel>? RentalPointEditViewModel { get; set; }
    }
}
