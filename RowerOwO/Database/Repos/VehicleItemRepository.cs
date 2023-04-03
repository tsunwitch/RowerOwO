using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;
using System.Security.Cryptography.X509Certificates;

namespace RowerOwO.Database.Repos
{
    public class VehicleItemRepository
    {
        private readonly BikeContext ctx;

        public VehicleItemRepository(BikeContext ctx) 
        {
            this.ctx = ctx;
        }

        public List<VehicleItemModel> GetAll()
        {
            return ctx.Vehicles.ToList();
        }
    }
}
