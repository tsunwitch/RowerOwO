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

        public RentalPointModel Get(Guid id)
        {
            return ctx.RentalPoints.FirstOrDefault(r => r.Id == id);
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

        public void Edit(Guid id, string name, string city, string street, string number)
        {
            var rentalPointToEdit = ctx.RentalPoints.FirstOrDefault(r => r.Id == id);

            rentalPointToEdit.Name = name;
            rentalPointToEdit.City = city;
            rentalPointToEdit.Street = street;
            rentalPointToEdit.Number = number;

            ctx.SaveChanges();
        }
    }
}
