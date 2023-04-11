using RowerOwO.Database.Repos;
using RowerOwO.Models;
using System.ComponentModel.DataAnnotations;

namespace RowerOwO.ViewModels
{
    public class VehicleDetailsViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Wprowadź imię")]
        [StringLength(32, ErrorMessage = "Wprowadzona nazwa nie może mieć więcej niż 32 znaki")]
        public string? Name { get; set; }
        [Url(ErrorMessage = "Wprowadź poprawny link")]
        public string? ImgPath { get; set; }
        [StringLength(255, ErrorMessage = "Wprowadzony opis nie może mieć więcej niż 255 znaków")]
        public string? Description { get; set; }
        public bool? Powered { get; set; }
        public string? Color { get; set; }
        public double? RentPrice { get; set; }
        public string? Type { get; set; }
    }
}
