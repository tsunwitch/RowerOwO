namespace RowerOwO.ViewModels
{
    public class VehicleCreateViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImgPath { get; set; }
        public string? Description { get; set; }
        public bool? Powered { get; set; }
        public string? Color { get; set; }
        public double? RentPrice { get; set; }
        public string Type { get; set; } = "Rower";
    }
}
