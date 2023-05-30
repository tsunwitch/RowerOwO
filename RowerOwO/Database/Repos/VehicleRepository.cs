using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using RowerOwO.Models;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

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

        public VehicleModel Get(Guid id)
        {
            var vehicleToReturn =  ctx.Vehicles.FirstOrDefault(r => r.Id ==  id);

            if (vehicleToReturn != null)
            {
                return vehicleToReturn;
            }
            else
            {
                throw new Exception();
            }
        }

        public void ChangeAvailability(Guid id)
        {
            var vehicleToChange = ctx.Vehicles.FirstOrDefault(r => r.Id == id);
            vehicleToChange.IsAvailable = !vehicleToChange.IsAvailable;
        }

        public void Create(string name, string imgPath, string description, bool powered, string color, double rentPrice, string type)
        {
            ctx.Vehicles.Add(new VehicleModel
            {
                //Id = Guid.NewGuid(),
                Name = name,
                IsAvailable = true,
                ImgPath = imgPath,
                Description = description,
                Powered = powered,
                Color = color,
                RentPrice = rentPrice,
                Type = type
            });

            ctx.SaveChanges();
        }

        public void Edit(Guid id, string name, string description, bool powered, string color, double rentPrice, string type)
        {
            var vehicleToEdit = ctx.Vehicles.FirstOrDefault(r => r.Id == id);

            vehicleToEdit.Name = name;
            //vehicleToEdit.ImgPath = imgPath;
            vehicleToEdit.Description = description;
            vehicleToEdit.Powered = powered;
            vehicleToEdit.Color = color;
            vehicleToEdit.RentPrice = rentPrice;
            vehicleToEdit.Type = type;

            ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var vehicleToDelete = ctx.Vehicles.FirstOrDefault(r => r.Id == id);
            ctx.Vehicles.Remove(vehicleToDelete);
            ctx.SaveChanges();
        }
    }
}
