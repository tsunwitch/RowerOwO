using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerOwO.Models
{
    public class VehicleItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string ImgPath { get; set; }
        public Guid DetailId { get; set; }
    }
}
