using RowerOwO.Models;

namespace RowerOwO.Areas.Admin.ViewModels
{
    public class RentalCRUDViewModel
    {
        public Guid Id { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public virtual RentalPointModel? RentalPoint { get; set; }
        public string? RentFrom { get; set; }
        public string? RentTill { get; set; }
        public bool IsActive { get; set; }
    }
}
