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

        public void Create(string name, string city, string street, string number)
        {
            ctx.RentalPoints.Add(new RentalPointModel
            {
                Name = name,
                City = city,
                Street = street,
                Number = number
            });

            ctx.SaveChanges();
        }
    }
}
