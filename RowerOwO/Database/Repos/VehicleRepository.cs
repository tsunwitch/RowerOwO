using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;
using System.Security.Cryptography.X509Certificates;

namespace RowerOwO.Database.Repos
{
    public class VehicleRepository
    {
        private readonly DatabaseContext ctx;

        public VehicleRepository(DatabaseContext ctx) 
        {
            this.ctx = ctx;
        }

        public List<VehicleModel> GetAll()
        {
            return ctx.Vehicles.ToList();
        }

        public VehicleModel Get(int id)
        {
            return ctx.Vehicles.FirstOrDefault(r => r.Id ==  id);
        }
    }
}
