using RowerOwO.Models;

namespace RowerOwO.Database.Repos
{
    public class VehicleDetailRepository
    {
        private readonly BikeContext ctx;
        public VehicleDetailRepository(BikeContext ctx)
        {
            this.ctx = ctx;
        }

        public List<VehicleDetailModel> GetAll()
        {

            var detailsList = ctx.VehicleDetails.ToList();
            return detailsList;
        }
    }
}
