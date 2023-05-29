using RowerOwO.Models;

namespace RowerOwO.Areas.Admin.ViewModels
{
    public class RentalListViewModel
    {
        public Guid Id { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }
    }
}
