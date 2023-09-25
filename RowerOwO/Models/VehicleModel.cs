using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerOwO.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? IsAvailable { get; set; } = true;
        public string? ImgPath { get; set; }
        public string? Description { get; set; }
        public bool? Powered { get; set; }
        public string? Color { get; set; }
        public double? RentPrice { get; set; }
        public string Type { get; set; } = "Rower";
        public virtual RentalPointModel RentalPoint { get; set; }
    }
}
