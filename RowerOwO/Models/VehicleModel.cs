using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerOwO.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; } = "some description";
        public bool Powered { get; set; } = false;
        public string Color { get; set; } = "some color";
        public double RentPrice { get; set; } = 0;
    }
}
