using System.ComponentModel.DataAnnotations;

namespace RowerOwO.Models
{
    public class RentModel
    {
        public int Id { get; set; }
        public enum Type
        {
            Rower,
            Deskorolka,
            Hulajnoga,
            Quad,
            Monocykl
        }
        public virtual VehicleItemModel Vehicle { get; set; }
        public virtual RentalPointModel Point { get; set; }
        public DateOnly RentFrom { get; set; }
        public DateOnly RentTill { get; set; }

    }
}
