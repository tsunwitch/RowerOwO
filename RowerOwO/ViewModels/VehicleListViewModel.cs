using RowerOwO.Database.Repos;
using RowerOwO.Models;

namespace RowerOwO.ViewModels
{
    public class VehicleListViewModel
    {
        //Attributes
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
