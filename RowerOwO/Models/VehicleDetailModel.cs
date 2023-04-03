namespace RowerOwO.Models
{
    public class VehicleDetailModel
    {
        public Guid Id { get; set; }
        public string Description { get; set;}
        public bool Powered { get; set; }
        public string Color { get; set; }
        public double RentPrice { get; set; }
    }
}
