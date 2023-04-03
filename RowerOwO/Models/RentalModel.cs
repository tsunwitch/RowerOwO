using System.ComponentModel.DataAnnotations;

namespace RowerOwO.Models
{
    public class RentalModel
    {
        public Guid Id{ get; set; }
        public virtual VehicleModel Vehicle { get; set; }
        public virtual RentalPointModel Point { get; set; }
        public DateOnly RentFrom { get; set; }
        public DateOnly RentTill { get; set; }

    }
}
