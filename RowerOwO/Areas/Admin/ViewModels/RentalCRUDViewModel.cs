using RowerOwO.Models;

namespace RowerOwO.Areas.Admin.ViewModels
{
    public class RentalCRUDViewModel
    {
        public Guid Id { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public virtual RentalPointModel? RentalPoint { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }
        public bool IsActive { get; set; }
    }
}
