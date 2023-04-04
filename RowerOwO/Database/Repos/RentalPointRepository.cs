using Microsoft.AspNetCore.Mvc;
using RowerOwO.Models;

namespace RowerOwO.Database.Repos
{
    public class RentalPointRepository
    {
        private readonly DatabaseContext ctx;

        public RentalPointRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public List<RentalPointModel> GetAll()
        {
            return ctx.RentalPoints.ToList();
        }
    }
}
