﻿using RowerOwO.Areas.Users.Models;
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

        public void Create(VehicleModel vehicle, RentalPointModel rentalPoint, DateOnly dateFrom, DateOnly dateTill)
        {
            ctx.Rentals.Add(new RentalModel
            {
                Vehicle = vehicle,
                Point = rentalPoint,
                RentFrom = dateFrom,
                RentTill = dateTill
            });

            ctx.SaveChanges();
        }

        public void Edit(Guid id, VehicleModel vehicle, RentalPointModel rentalPoint, DateOnly dateFrom, DateOnly dateTill)
        {
            var rentalToEdit = ctx.Rentals.FirstOrDefault(r => r.Id == id);

            rentalToEdit.Vehicle = vehicle;
            rentalToEdit.Point = rentalPoint;
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
