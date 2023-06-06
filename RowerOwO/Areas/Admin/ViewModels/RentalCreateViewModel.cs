using RowerOwO.Models;

namespace RowerOwO.Areas.Admin.ViewModels
{
    public class RentalCreateViewModel
    {
        public Guid Id { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public virtual RentalPointModel? RentalPoint { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }
        public virtual List<VehicleModel>? VehicleList { get; set; }
        public virtual List<RentalPointModel>? RentalPointList { get; set;}
    }
}
