using RowerOwO.Areas.Users.Models;
using RowerOwO.Models;
using RowerOwO.ViewModels;

namespace RowerOwO.Database.Repos
{
    public class RentalRepository
    {
        private readonly DatabaseContext ctx;

        public RentalRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public List<RentalModel> GetAll()
        {
            return ctx.Rentals.ToList();
        }

        public RentalModel Get(Guid id)
        {
            return ctx.Rentals.FirstOrDefault(r => r.Id == id);
        }

        public void ChangeAvailability (Guid id)
        {
            var rentalToChange = ctx.Rentals.FirstOrDefault(r => r.Id == id);
            rentalToChange.IsActive = !rentalToChange.IsActive;

            ctx.SaveChanges();
        }

        public void Create(VehicleModel vehicle, RentalPointModel rentalPoint, string dateFrom, string dateTill)
        {
            ctx.Rentals.Add(new RentalModel
            {
                Vehicle = vehicle,
                RentalPoint = rentalPoint,
                RentFrom = dateFrom,
                RentTill = dateTill,
                IsActive = true
            });

            ctx.SaveChanges();
        }

        public void Edit(Guid id, VehicleModel vehicle, RentalPointModel rentalPoint, string dateFrom, string dateTill)
        {
            var rentalToEdit = ctx.Rentals.FirstOrDefault(r => r.Id == id);

            rentalToEdit.Vehicle = vehicle;
            rentalToEdit.RentalPoint = rentalPoint;
            rentalToEdit.RentFrom = dateFrom;
            rentalToEdit.RentTill = dateTill;

            ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var rentalToDelete = ctx.Rentals.FirstOrDefault(r => r.Id == id);

            ctx.Rentals.Remove(rentalToDelete);
            ctx.SaveChanges();
        }
    }
}
