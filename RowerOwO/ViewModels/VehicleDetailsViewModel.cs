using RowerOwO.Database.Repos;
using RowerOwO.Models;

namespace RowerOwO.ViewModels
{
    public class VehicleDetailsViewModel
    {
        public static VehicleItemRepository itemRepo = new();
        public static VehicleDetailRepository detailRepo = new();
        

        public List<VehicleDetailsViewModel> GetVehicles()
        {
            return ;
        }
    }
}
