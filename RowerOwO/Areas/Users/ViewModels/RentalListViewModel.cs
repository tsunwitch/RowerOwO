using RowerOwO.Models;

namespace RowerOwO.Areas.Users.ViewModels
{
    public class RentalListViewModel
    { 
        public Guid Id { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }
    }
}
